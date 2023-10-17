using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class SupplierController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public SupplierController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }//Task<IEnumerable<Person>> GetSuppliersByProduct(string product)

        [HttpGet("GetSuppliersByProduct/{Product}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliersByProduct(string product) 
        {
            var people = await _unitOfWork.People.GetSuppliersByProduct(product);
            return _mapper.Map<List<SupplierDto>>(people);        
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<SupplierDto>>> Get() 
        {
            var people = await _unitOfWork.People.GetAllAsync();
            return _mapper.Map<List<SupplierDto>>(people);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SupplierDto>>> Get11([FromQuery] Params SupplierParams )
        {
            var people = await _unitOfWork.People.GetAllAsync(SupplierParams.PageIndex,SupplierParams.PageSize,SupplierParams.Search);
            var lstSupplierDto = _mapper.Map<List<SupplierDto>>(people.registros);
            return new Pager<SupplierDto>(lstSupplierDto,people.totalRegistros,SupplierParams.PageIndex,SupplierParams.PageSize,SupplierParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(Id);
            return Ok(people);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(Person Supplier)
        {
            _unitOfWork.People.Add(Supplier);
            await _unitOfWork.SaveAsync();
            if (Supplier == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Supplier.Id }, Supplier);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Person>> Put(int id, [FromBody] Person Supplier)
        {
            if (Supplier == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Update(Supplier);
            await _unitOfWork.SaveAsync();

            return Supplier;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Remove(people);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }