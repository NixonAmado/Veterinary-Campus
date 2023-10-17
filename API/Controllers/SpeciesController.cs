using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
        public async Task<ActionResult<SpeciesDto>> GetPetGrouped() 
        {
            var species = await _unitOfWork.Species.GetPetBySpecies();
            return _mapper.Map<SpeciesDto>(species);        
        
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<SpeciesDto>> Get() 
        {
            var species = await _unitOfWork.Species.GetAllAsync();
            return _mapper.Map<SpeciesDto>(species);        
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SpeciesDto>>> Get11([FromQuery] Params SpeciesParams )
        {
            var species = await _unitOfWork.Species.GetAllAsync(SpeciesParams.PageIndex,SpeciesParams.PageSize,SpeciesParams.Search);
            var lstSpeciesDto = _mapper.Map<List<SpeciesDto>>(species.registros);
            return new Pager<SpeciesDto>(lstSpeciesDto,species.totalRegistros,SpeciesParams.PageIndex,SpeciesParams.PageSize,SpeciesParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var species = await _unitOfWork.Species.GetByIdAsync(Id);
            return Ok(species);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Species>> Post(SpeciesDto SpeciesDto)
        {
            var species = _mapper.Map<Species>(SpeciesDto);
            _unitOfWork.Species.Add(species);
            await _unitOfWork.SaveAsync();
            if (SpeciesDto == null)
            {
                return BadRequest();
            }
            SpeciesDto.Id = species.Id;
            return CreatedAtAction(nameof(Post), new { id = SpeciesDto.Id }, SpeciesDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<SpeciesDto>> Put(int id, [FromBody] SpeciesDto SpeciesDto)
        {
            if (SpeciesDto == null)
            {
                return NotFound();
            }
            var species = _mapper.Map<Species>(SpeciesDto);
            _unitOfWork.Species.Update(species);
            await _unitOfWork.SaveAsync();

            return SpeciesDto;
        }

        [HttpDelete("{id}")]
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