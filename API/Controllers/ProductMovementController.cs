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

    public class ProductMovementController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProductMovementController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
        [HttpGet("GetProductMovementAndVal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<ProductMovementDto>>> GetProdMove() 
        {
            var productMovements = await _unitOfWork.ProductMovements.GetProductMovement();
            return _mapper.Map<List<ProductMovementDto>>(productMovements);        
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<ProductMovementDto>>> Get() 
        {
            var productMovements = await _unitOfWork.ProductMovements.GetAllAsync();
            return _mapper.Map<List<ProductMovementDto>>(productMovements);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProductMovementDto>>> Get11([FromQuery] Params ProductMovementParams )
        {
            var productMovements = await _unitOfWork.ProductMovements.GetAllAsync(ProductMovementParams.PageIndex,ProductMovementParams.PageSize,ProductMovementParams.Search);
            var lstProductMovementDto = _mapper.Map<List<ProductMovementDto>>(productMovements.registros);
            return new Pager<ProductMovementDto>(lstProductMovementDto,productMovements.totalRegistros,ProductMovementParams.PageIndex,ProductMovementParams.PageSize,ProductMovementParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var productMovement = await _unitOfWork.ProductMovements.GetByIdAsync(Id);
            return Ok(productMovement);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductMovement>> Post(ProductMovement ProductMovement)
        {
            _unitOfWork.ProductMovements.Add(ProductMovement);
            await _unitOfWork.SaveAsync();
            if (ProductMovement == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = ProductMovement.Id }, ProductMovement);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<ProductMovement>> Put(int id, [FromBody] ProductMovement ProductMovement)
        {
            if (ProductMovement == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductMovements.Update(ProductMovement);
            await _unitOfWork.SaveAsync();

            return ProductMovement;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var productMovement = await _unitOfWork.ProductMovements.GetByIdAsync(id);
            if (productMovement == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductMovements.Remove(productMovement);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }