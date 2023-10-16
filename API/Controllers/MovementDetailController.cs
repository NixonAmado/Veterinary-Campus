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

    public class MovementDetailController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public MovementDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<MovementDetailDto>>> Get() 
        {
            var movementDetails = await _unitOfWork.MovementDetails.GetAllAsync();
            return _mapper.Map<List<MovementDetailDto>>(movementDetails);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MovementDetailDto>>> Get11([FromQuery] Params MovementDetailParams )
        {
            var movementDetails = await _unitOfWork.MovementDetails.GetAllAsync(MovementDetailParams.PageIndex,MovementDetailParams.PageSize,MovementDetailParams.Search);
            var lstMovementDetailDto = _mapper.Map<List<MovementDetailDto>>(movementDetails.registros);
            return new Pager<MovementDetailDto>(lstMovementDetailDto,movementDetails.totalRegistros,MovementDetailParams.PageIndex,MovementDetailParams.PageSize,MovementDetailParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var movementDetails = await _unitOfWork.MovementDetails.GetByIdAsync(Id);
            return Ok(movementDetails);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementDetail>> Post(MovementDetail MovementDetail)
        {
            _unitOfWork.MovementDetails.Add(MovementDetail);
            await _unitOfWork.SaveAsync();
            if (MovementDetail == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = MovementDetail.Id }, MovementDetail);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<MovementDetail>> Put(int id, [FromBody] MovementDetail MovementDetail)
        {
            if (MovementDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementDetails.Update(MovementDetail);
            await _unitOfWork.SaveAsync();

            return MovementDetail;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var movementDetails = await _unitOfWork.MovementDetails.GetByIdAsync(id);
            if (movementDetails == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementDetails.Remove(movementDetails);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }