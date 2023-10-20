using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public class PetController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PetController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //Listar las mascotas y sus propietarios cuya raza sea Golden Retriver
        [HttpGet("GetOwnerPetByBreed/{Breed}")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<IEnumerable<FullPetDto>>> GetOwnerPetByBreed(string breed) 
        {
            var pets = await _unitOfWork.Pets.GetOwnerPetByBreed(breed);
            return _mapper.Map<List<FullPetDto>>(pets);        
        }

    

        //Listar las mascotas que fueron atendidas por motivo de vacunacion en el X trimestre del X
        [HttpGet("GetByReasonInTrimYear/{trim}/{year}/{reason}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<IEnumerable<PetStatDto>>> GetBySpecies(int trim, int year, string reason) 
        {
            var pets = await _unitOfWork.Pets.GetAttendedByReasonInTrimesterYear(trim, year, reason);
            return _mapper.Map<List<PetStatDto>>(pets);        
        }

        //Mostrar las mascotas que se encuentren registradas cuya especie sea felina.
        [HttpGet("GetBySpecies/{Species}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<IEnumerable<PetStatDto>>> GetBySpecies(string species) 
        {
            var pets = await _unitOfWork.Pets.GetAllBySpecies(species);
            return _mapper.Map<List<PetStatDto>>(pets);        
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<PetStatDto>>> Get() 
        {
            var pets = await _unitOfWork.Pets.GetAllAsync();
            return _mapper.Map<List<PetStatDto>>(pets);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<FullPetDto>>> Get11([FromQuery] Params PetParams )
        {
            var pets = await _unitOfWork.Pets.GetAllAsync(PetParams.PageIndex,PetParams.PageSize,PetParams.Search);
            var lstFullPetDto = _mapper.Map<List<FullPetDto>>(pets.registros);
            return new Pager<FullPetDto>(lstFullPetDto,pets.totalRegistros,PetParams.PageIndex,PetParams.PageSize,PetParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetStatDto>> Get(int Id)
        {
            var pet = await _unitOfWork.Pets.GetByIdAsync(Id);
            return _mapper.Map<PetStatDto>(pet);
        }




        [HttpPost]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pet>> Post(Pet Pet)
        {
            _unitOfWork.Pets.Add(Pet);
            await _unitOfWork.SaveAsync();
            if (Pet == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Pet.Id }, Pet);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Pet>> Put(int id, [FromBody] Pet Pet)
        {
            if (Pet == null)
            {
                return NotFound();
            }
            _unitOfWork.Pets.Update(Pet);
            await _unitOfWork.SaveAsync();

            return Pet;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var pets = await _unitOfWork.Pets.GetByIdAsync(id);
            if (pets == null)
            {
                return NotFound();
            }
            _unitOfWork.Pets.Remove(pets);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }