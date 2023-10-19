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
    public class MovementTypeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public MovementTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<MovementTypeDto>>> Get() 
        {
            var movementTypes = await _unitOfWork.MovementTypes.GetAllAsync();
            return _mapper.Map<List<MovementTypeDto>>(movementTypes);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MovementTypeDto>>> Get11([FromQuery] Params MovementTypeParams )
        {
            var movementTypes = await _unitOfWork.MovementDetails.GetAllAsync(MovementTypeParams.PageIndex,MovementTypeParams.PageSize,MovementTypeParams.Search);
            var lstMovementTypeDto = _mapper.Map<List<MovementTypeDto>>(movementTypes.registros);
            return new Pager<MovementTypeDto>(lstMovementTypeDto,movementTypes.totalRegistros,MovementTypeParams.PageIndex,MovementTypeParams.PageSize,MovementTypeParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var movementTypes = await _unitOfWork.MovementTypes.GetByIdAsync(Id);
            return Ok(movementTypes);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementType>> Post(MovementType MovementType)
        {
            _unitOfWork.MovementTypes.Add(MovementType);
            await _unitOfWork.SaveAsync();
            if (MovementType == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = MovementType.Id }, MovementType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<MovementType>> Put(int id, [FromBody] MovementType MovementType)
        {
            if (MovementType == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementTypes.Update(MovementType);
            await _unitOfWork.SaveAsync();

            return MovementType;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var movementTypes = await _unitOfWork.MovementTypes.GetByIdAsync(id);
            if (movementTypes == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementTypes.Remove(movementTypes);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }