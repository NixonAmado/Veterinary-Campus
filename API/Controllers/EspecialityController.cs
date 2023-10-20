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
    public class EspecialityController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public EspecialityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<EspecialityDto>>> Get() 
        {
            var especialities = await _unitOfWork.Especialities.GetAllAsync();
            return _mapper.Map<List<EspecialityDto>>(especialities);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EspecialityDto>>> Get11([FromQuery] Params EspecialityParams )
        {
            var especiality = await _unitOfWork.Especialities.GetAllAsync(EspecialityParams.PageIndex,EspecialityParams.PageSize,EspecialityParams.Search);
            var lstEspecialityDto = _mapper.Map<List<EspecialityDto>>(especiality.registros);
            return new Pager<EspecialityDto>(lstEspecialityDto,especiality.totalRegistros,EspecialityParams.PageIndex,EspecialityParams.PageSize,EspecialityParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecialityDto>> Get(int Id)
        {
            var especiality = await _unitOfWork.Especialities.GetByIdAsync(Id);
            return _mapper.Map<EspecialityDto>(especiality);
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Especiality>> Post(Especiality Especiality)
        {
            _unitOfWork.Especialities.Add(Especiality);
            await _unitOfWork.SaveAsync();
            if (Especiality == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Especiality.Id }, Especiality);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Especiality>> Put(int id, [FromBody] Especiality Especiality)
        {
            if (Especiality == null)
            {
                return NotFound();
            }
            _unitOfWork.Especialities.Update(Especiality);
            await _unitOfWork.SaveAsync();

            return Especiality;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var especiality = await _unitOfWork.Especialities.GetByIdAsync(id);
            if (especiality == null)
            {
                return NotFound();
            }
            _unitOfWork.Especialities.Remove(especiality);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }