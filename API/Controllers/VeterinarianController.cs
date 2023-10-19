using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class VeterinarianController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public VeterinarianController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //Listar las mascotas que fueron atendidas por un determinado veterinario.
        [HttpGet("PetsAttendedByVet/{veterinarian}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<PetStatDto>>> PetsAttendedByVet(string veterinarian) 
        {
            var PetsAttendedByVet = await _unitOfWork.People.PetsAttendedByVet(veterinarian);
            return _mapper.Map<List<PetStatDto>>(PetsAttendedByVet);        
        }

        //Crear un consulta que permita visualizar los veterinarios cuya especialidad sea X.
        [HttpGet("GetByEspeciality/{Especiality}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<VeterinarianDto>>> GetByEspeciality(string especiality) 
        {
            var veterinarian = await _unitOfWork.People.GetVetByEspecialityAsync(especiality);
            return _mapper.Map<List<VeterinarianDto>>(veterinarian);        
        }


        [HttpGet]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<VeterinarianDto>>> Get() 
        {
            var veterinarian = await _unitOfWork.People.GetAllVeterinarianAsync();
            return _mapper.Map<List<VeterinarianDto>>(veterinarian);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VeterinarianDto>>> Get11([FromQuery] Params VeterinarianParams )
        {
            var veterinarian = await _unitOfWork.People.GetAllPeopleAsync(VeterinarianParams.PageIndex,VeterinarianParams.PageSize,VeterinarianParams.Search,"veterinario");
            var lstVeterinarianDto = _mapper.Map<List<VeterinarianDto>>(veterinarian.registros);
            return new Pager<VeterinarianDto>(lstVeterinarianDto,veterinarian.totalRegistros,VeterinarianParams.PageIndex,VeterinarianParams.PageSize,VeterinarianParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var veterinarian = await _unitOfWork.People.GetByIdAsync(Id);
            return Ok(veterinarian);
        }



        [HttpPost]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(Person Veterinarian)
        {
            _unitOfWork.People.Add(Veterinarian);
            await _unitOfWork.SaveAsync();
            if (Veterinarian == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Veterinarian.Id }, Veterinarian);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Person>> Put(int id, [FromBody] Person Veterinarian)
        {
            if (Veterinarian == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Update(Veterinarian);
            await _unitOfWork.SaveAsync();

            return Veterinarian;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var veterinarian = await _unitOfWork.People.GetByIdAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Remove(veterinarian);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }