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
    [Authorize(Roles = "Empleado,Administrador")]
    public class LaboratoryController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public LaboratoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<LaboratoryDto>>> Get() 
        {
            var laboratories = await _unitOfWork.Laboratories.GetAllAsync();
            return _mapper.Map<List<LaboratoryDto>>(laboratories);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<LaboratoryDto>>> Get11([FromQuery] Params LaboratoryParams )
        {
            var laboratories = await _unitOfWork.Laboratories.GetAllAsync(LaboratoryParams.PageIndex,LaboratoryParams.PageSize,LaboratoryParams.Search);
            var lstLaboratoryDto = _mapper.Map<List<LaboratoryDto>>(laboratories.registros);
            return new Pager<LaboratoryDto>(lstLaboratoryDto,laboratories.totalRegistros,LaboratoryParams.PageIndex,LaboratoryParams.PageSize,LaboratoryParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var laboratory = await _unitOfWork.Laboratories.GetByIdAsync(Id);
            return Ok(laboratory);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Laboratory>> Post(Laboratory Laboratory)
        {
            _unitOfWork.Laboratories.Add(Laboratory);
            await _unitOfWork.SaveAsync();
            if (Laboratory == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Laboratory.Id }, Laboratory);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Laboratory>> Put(int id, [FromBody] Laboratory Laboratory)
        {
            if (Laboratory == null)
            {
                return NotFound();
            }
            _unitOfWork.Laboratories.Update(Laboratory);
            await _unitOfWork.SaveAsync();

            return Laboratory;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var laboratories = await _unitOfWork.Laboratories.GetByIdAsync(id);
            if (laboratories == null)
            {
                return NotFound();
            }
            _unitOfWork.Laboratories.Remove(laboratories);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }