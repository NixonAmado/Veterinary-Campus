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

    public class OwnerController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public OwnerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("GetAllOwnersAndPets")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<OwnerPetDto>>> GetAllOwnersPets() 
        {
            var owners = await _unitOfWork.People.GetAllOwnersAndPets();
            return _mapper.Map<List<OwnerPetDto>>(owners);        
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<OwnerDto>>> Get() 
        {
            var owners = await _unitOfWork.People.GetAllOwnersAsync();
            return _mapper.Map<List<OwnerDto>>(owners);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<OwnerDto>>> Get11([FromQuery] Params OwnerParams )
        {
            var owners = await _unitOfWork.People.GetAllPeopleAsync(OwnerParams.PageIndex,OwnerParams.PageSize,OwnerParams.Search,"propietario");
            var lstOwnerDto = _mapper.Map<List<OwnerDto>>(owners.registros);
            return new Pager<OwnerDto>(lstOwnerDto,owners.totalRegistros,OwnerParams.PageIndex,OwnerParams.PageSize,OwnerParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var owner = await _unitOfWork.People.GetByIdAsync(Id);
            return Ok(owner);
        }



        [HttpPost]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(OwnerDto OwnerDto)
        {
            var owner = _mapper.Map<Person>(OwnerDto);
            _unitOfWork.People.Add(owner);
            await _unitOfWork.SaveAsync();
            if (OwnerDto == null)
            {
                return BadRequest();
            }
            OwnerDto.Id = owner.Id;
            return CreatedAtAction(nameof(Post), new { id = OwnerDto.Id }, OwnerDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Person>> Put(int id, [FromBody] Person Owner)
        {
            if (Owner == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Update(Owner);
            await _unitOfWork.SaveAsync();

            return Owner;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var owners = await _unitOfWork.People.GetByIdAsync(id);
            if (owners == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Remove(owners);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }