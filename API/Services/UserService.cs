using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
using Domain.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    public UserService(IPasswordHasher<User> passwordHasher, IUnitOfWork unitOfWork, IOptions<JWT> jwt)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _jwt = jwt.Value;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
         var User = new User
        {
            Email = registerDto.Email,
            Name = registerDto.Name,
        };
        User.Password = _passwordHasher.HashPassword(User, registerDto.Password); //Encrypt password

        var existingUser = _unitOfWork.Users
                                    .Find(u => u.Name.ToLower() == registerDto.Name.ToLower())
                                    .FirstOrDefault();
        if (existingUser == null)
        {
            var rolDefault = _unitOfWork.Roles
                                    .Find(u => u.Description == Authorization.rol_default.ToString())
                                    .First();
            try
            {
                User.Roles.Add(rolDefault);
                _unitOfWork.Users.Add(User);
                await _unitOfWork.SaveAsync();

                return $"{registerDto.Name} ha sido registrado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"El User {registerDto.Name} ya existe!";
        }
    }

    //Agregar Roles al User
    public async Task<string> AddRoleAsync(AddRoleDto addRol)
    {
        var User = await _unitOfWork.Users
                            .GetByNameAsync(addRol.Name);

        if (User == null)
        {
            return $"{addRol.Name} No existe!!.";
        }

        var resultado = _passwordHasher.VerifyHashedPassword(User, User.Password, addRol.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Roles
                                            .Find(u => u.Description.ToLower() == addRol.Role.ToLower())
                                            .FirstOrDefault();

            if (rolExiste != null)
            {
                var usuarioTieneRol = User.Roles
                                                .Any(u => u.Id == rolExiste.Id);

                if (usuarioTieneRol == false)
                {
                    User.Roles.Add(rolExiste);
                    _unitOfWork.Users.Update(User);
                    await _unitOfWork.SaveAsync();
                }

                return $"Role {addRol.Role} agregado a la cuenta {addRol.Name} de forma exitosa.";
            }

            return $"Role {addRol.Role} no encontrado.";
        }

        return $"Credenciales incorrectas para el ususario {User.Name}.";
    }



    public async Task<DataUserDto> GetTokenAsync(LoginDto login)
    {
        DataUserDto datosUsuarioDto = new();
        var User = await _unitOfWork.Users.GetByNameAsync(login.Name);

        if (User == null)
        {
            datosUsuarioDto.IsAuthenticated = false;
            datosUsuarioDto.Message = $"{login.Name} No existe!!.";
            return datosUsuarioDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(User, User.Password, login.Password);
        if (result == PasswordVerificationResult.Success)
        {
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(User);

            datosUsuarioDto.Message = "OK";
            datosUsuarioDto.IsAuthenticated = true;
            datosUsuarioDto.Name = User.Name;
            datosUsuarioDto.Email = User.Email;
            datosUsuarioDto.Roles = User.Roles
                                        .Select(p => p.Description)
                                        .ToList();
            datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            User.RefreshTokens ??= new List<RefreshToken>();

            if (User.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = User.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                datosUsuarioDto.RefreshToken = activeRefreshToken.Token;
                datosUsuarioDto.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                datosUsuarioDto.RefreshToken = refreshToken.Token;
                datosUsuarioDto.RefreshTokenExpiration = refreshToken.Expires;
                User.RefreshTokens.Add(refreshToken);
                _unitOfWork.Users.Update(User);
                await _unitOfWork.SaveAsync();
            }

            return datosUsuarioDto;
        }    
        else
        {
            datosUsuarioDto.IsAuthenticated = false;
            datosUsuarioDto.Message = $"Credenciales incorrectas para el User {User.Name}.";   
        }
        return datosUsuarioDto;
    }



    private JwtSecurityToken CreateJwtToken(User User)
    {
        if (User == null)
        {
            throw new ArgumentNullException(nameof(User), "El User no puede ser nulo.");
        }

        var roles = User.Roles;
        var rolClaims = new List<Claim>();
        foreach (var rolERole in roles)
        {
            rolClaims.Add(new Claim("roles", rolERole.Description));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, User.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("uid", User.Id.ToString())
        }
        .Union(rolClaims);

        if (string.IsNullOrEmpty(_jwt.Key) || string.IsNullOrEmpty(_jwt.Issuer) || string.IsNullOrEmpty(_jwt.Audience))
        {
            throw new ArgumentNullException("La configuración del JWT es nula o vacía.");
        }

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        var JwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

        return JwtSecurityToken;
    }


    public async Task<DataUserDto> RefreshTokenAsync(string refreshToken)
    {
        var dataUserDto = new DataUserDto();
        var User = await _unitOfWork.Users.GetByRefreshTokenAsync(refreshToken);

        if (User == null)
        {
            dataUserDto.IsAuthenticated = false;
            dataUserDto.Message = "El token no está asignado a ningún User.";
            return dataUserDto;
        }

        var refreshTokenBd = User.RefreshTokens.Single(x => x.Token == refreshToken);

        if (refreshTokenBd.IsExpired)
        {
            // El token de actualización ha expirado, (Revoca el token)
            refreshTokenBd.Revoked = DateTime.UtcNow;
            await _unitOfWork.SaveAsync();

            dataUserDto.IsAuthenticated = false;
            dataUserDto.Message = "El Token de Actualizacion ha expirado. Iniciar sesión nuevamente.";
            return dataUserDto;
        }

        // El token de actualización está activo y no ha expirado
        // Generar un nuevo token de acceso
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(User);
        dataUserDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        dataUserDto.RefreshToken = refreshToken; 
        dataUserDto.RefreshTokenExpiration = refreshTokenBd.Expires;
        dataUserDto.IsAuthenticated = true;
        dataUserDto.Email = User.Email;
        dataUserDto.Name = User.Name;
        dataUserDto.Roles = User.Roles.Select(u => u.Description).ToList();

        return dataUserDto;
    }



    private static RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Created = DateTime.UtcNow
            };
        }
    }

    
}