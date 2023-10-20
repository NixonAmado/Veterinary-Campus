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

    public class SpeciesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public SpeciesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetPetGroupedBySpecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        //Listar todas las mascotas agrupadas por especie.
        public async Task<ActionResult<IEnumerable<SpeciesDto>>> GetPetGrouped() 
        {
            var species = await _unitOfWork.Species.GetPetBySpecies();
            return _mapper.Map<List<SpeciesDto>>(species);        
        
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<SpeciesNameDto>>> Get() 
        {
            var species = await _unitOfWork.Species.GetAllAsync();
            return _mapper.Map<List<SpeciesNameDto>>(species);        
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SpeciesNameDto>>> Get11([FromQuery] Params SpeciesParams )
        {
            var species = await _unitOfWork.Species.GetAllAsync(SpeciesParams.PageIndex,SpeciesParams.PageSize,SpeciesParams.Search);
            var lstSpeciesDto = _mapper.Map<List<SpeciesNameDto>>(species.registros);
            return new Pager<SpeciesNameDto>(lstSpeciesDto,species.totalRegistros,SpeciesParams.PageIndex,SpeciesParams.PageSize,SpeciesParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpeciesDto>> Get(int Id)
        {
            var species = await _unitOfWork.Species.GetByIdAsync(Id);
            return _mapper.Map<SpeciesDto>(species);
        }


        [HttpPost]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Species>> Post(Species Species)
        {
            var species = _mapper.Map<Species>(Species);
            _unitOfWork.Species.Add(species);
            await _unitOfWork.SaveAsync();
            if (Species == null)
            {
                return BadRequest();
            }
            Species.Id = species.Id;
            return CreatedAtAction(nameof(Post), new { id = Species.Id }, Species);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Species>> Put(int id, [FromBody] Species Species)
        {
            if (Species == null)
            {
                return NotFound();
            }
            var species = _mapper.Map<Species>(Species);
            _unitOfWork.Species.Update(species);
            await _unitOfWork.SaveAsync();

            return Species;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var species = await _unitOfWork.Species.GetByIdAsync(id);
            if (species == null)
            {
                return NotFound();
            }
            _unitOfWork.Species.Remove(species);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }