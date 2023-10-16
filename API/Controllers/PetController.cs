using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<PetDto>>> Get() 
        {
            var pets = await _unitOfWork.Pets.GetAllAsync();
            return _mapper.Map<List<PetDto>>(pets);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PetDto>>> Get11([FromQuery] Params PetParams )
        {
            var pets = await _unitOfWork.Pets.GetAllAsync(PetParams.PageIndex,PetParams.PageSize,PetParams.Search);
            var lstPetDto = _mapper.Map<List<PetDto>>(pets.registros);
            return new Pager<PetDto>(lstPetDto,pets.totalRegistros,PetParams.PageIndex,PetParams.PageSize,PetParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var pets = await _unitOfWork.Pets.GetByIdAsync(Id);
            return Ok(pets);
        }



        [HttpPost]
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