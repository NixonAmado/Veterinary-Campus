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
    [Authorize(Roles = "Administrador,Empleado")]

    public class PersonTypeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get() 
        {
            var personTypes = await _unitOfWork.PersonTypes.GetAllAsync();
            return _mapper.Map<List<PersonTypeDto>>(personTypes);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonTypeDto>>> Get11([FromQuery] Params PersonTypeParams )
        {
            var personTypes = await _unitOfWork.PersonTypes.GetAllAsync(PersonTypeParams.PageIndex,PersonTypeParams.PageSize,PersonTypeParams.Search);
            var lstPersonTypeDto = _mapper.Map<List<PersonTypeDto>>(personTypes.registros);
            return new Pager<PersonTypeDto>(lstPersonTypeDto,personTypes.totalRegistros,PersonTypeParams.PageIndex,PersonTypeParams.PageSize,PersonTypeParams.Search);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonTypeDto>> Get(int Id)
        {
            var personType = await _unitOfWork.PersonTypes.GetByIdAsync(Id);
            return _mapper.Map<PersonTypeDto>(personType);
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonType>> Post(PersonType PersonType)
        {
            _unitOfWork.PersonTypes.Add(PersonType);
            await _unitOfWork.SaveAsync();
            if (PersonType == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = PersonType.Id }, PersonType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<PersonType>> Put(int id, [FromBody] PersonType PersonType)
        {
            if (PersonType == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonTypes.Update(PersonType);
            await _unitOfWork.SaveAsync();

            return PersonType;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var personType = await _unitOfWork.PersonTypes.GetByIdAsync(id);
            if (personType == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonTypes.Remove(personType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }