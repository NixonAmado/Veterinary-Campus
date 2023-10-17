using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class BreedController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public BreedController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<IActionResult> Get() 
        {
            var breeds = await _unitOfWork.Breeds.GetAllAsync();
            return Ok(breeds);        
        }

        [HttpGet("GetPetCountInBreed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<CountBreed>>> GetPetCountInBreed() 
        {
            var breedList = await _unitOfWork.Breeds.GetPetCountInBreed();
            return _mapper.Map<List<CountBreed>>(breedList);        
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<BreedDto>>> Get11([FromQuery] Params BreedParams )
        {
            var breed = await _unitOfWork.Appointments.GetAllAsync(BreedParams.PageIndex,BreedParams.PageSize,BreedParams.Search);
            var lstBreedDto = _mapper.Map<List<BreedDto>>(breed.registros);
            return new Pager<BreedDto>(lstBreedDto,breed.totalRegistros,BreedParams.PageIndex,BreedParams.PageSize,BreedParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var breed = await _unitOfWork.Breeds.GetByIdAsync(Id);
            return Ok(breed);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Breed>> Post(BreedDto BreedDto)
        {
            var breed = _mapper.Map<Breed>(BreedDto);
            _unitOfWork.Breeds.Add(breed);
            await _unitOfWork.SaveAsync();
            if (BreedDto == null)
            {
                return BadRequest();
            }
            BreedDto.Id = breed.Id;
            return CreatedAtAction(nameof(Post), new { id = BreedDto.Id }, BreedDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<BreedDto>> Put(int id, [FromBody] BreedDto BreedDto)
        {
            if (BreedDto == null)
            {
                return NotFound();
            }
            var appoinment = _mapper.Map<Breed>(BreedDto);
            _unitOfWork.Breeds.Update(appoinment);
            await _unitOfWork.SaveAsync();

            return BreedDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var breed = await _unitOfWork.Breeds.GetByIdAsync(id);
            if (breed == null)
            {
                return NotFound();
            }
            _unitOfWork.Breeds.Remove(breed);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }