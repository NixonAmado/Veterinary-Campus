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
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliersByProduct(string product) 
        {
            var people = await _unitOfWork.People.GetSuppliersByProduct(product);
            return _mapper.Map<List<SupplierDto>>(people);        
        }



        [HttpGet]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<SupplierDto>>> Get() 
        {
            var people = await _unitOfWork.People.GetAllSuppliersAsync();
            return _mapper.Map<List<SupplierDto>>(people);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SupplierDto>>> Get11([FromQuery] Params SupplierParams )
        {
            var people = await _unitOfWork.People.GetAllPeopleAsync(SupplierParams.PageIndex,SupplierParams.PageSize,SupplierParams.Search,"Proovedor");
            var lstSupplierDto = _mapper.Map<List<SupplierDto>>(people.registros);
            return new Pager<SupplierDto>(lstSupplierDto,people.totalRegistros,SupplierParams.PageIndex,SupplierParams.PageSize,SupplierParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SupplierDto>> Get(int Id)
        {
            var supplier = await _unitOfWork.People.GetOwnerByIdAsync(Id);
            return _mapper.Map<SupplierDto>(supplier);
        }



        [HttpPost]
        [Authorize(Roles = "Administrador,Empleado")]
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
        [Authorize(Roles = "Administrador,Empleado")]
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
        [Authorize(Roles = "Administrador,Empleado")]
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