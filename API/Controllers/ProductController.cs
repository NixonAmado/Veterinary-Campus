using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class ProductController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //Listar los medicamentos que pertenezcan a el laboratorio Genfar
        [HttpGet("GetByLab{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByLab(string name) 
        {
            var products = await _unitOfWork.Products.GetProdByLabAsync(name);
            return _mapper.Map<List<ProductDto>>(products);        
        }

        
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<ProductDto>>> Get() 
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProductDto>>> Get11([FromQuery] Params ProductParams )
        {
            var products = await _unitOfWork.Products.GetAllAsync(ProductParams.PageIndex,ProductParams.PageSize,ProductParams.Search);
            var lstProductDto = _mapper.Map<List<ProductDto>>(products.registros);
            return new Pager<ProductDto>(lstProductDto,products.totalRegistros,ProductParams.PageIndex,ProductParams.PageSize,ProductParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var products = await _unitOfWork.Products.GetByIdAsync(Id);
            return Ok(products);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(Product Product)
        {
            _unitOfWork.Products.Add(Product);
            await _unitOfWork.SaveAsync();
            if (Product == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Product.Id }, Product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Product>> Put(int id, [FromBody] Product Product)
        {
            if (Product == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Update(Product);
            await _unitOfWork.SaveAsync();

            return Product;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var products = await _unitOfWork.Products.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(products);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }