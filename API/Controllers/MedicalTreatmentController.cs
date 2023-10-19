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
    public class MedicalTreatmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public MedicalTreatmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<MedicalTreatmentDto>>> Get() 
        {
            var medicalTreatments = await _unitOfWork.MedicalTreatments.GetAllAsync();
            return _mapper.Map<List<MedicalTreatmentDto>>(medicalTreatments);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicalTreatmentDto>>> Get11([FromQuery] Params MedicalTreatmentParams )
        {
            var medicalTreatments = await _unitOfWork.MedicalTreatments.GetAllAsync(MedicalTreatmentParams.PageIndex,MedicalTreatmentParams.PageSize,MedicalTreatmentParams.Search);
            var lstMedicalTreatmentDto = _mapper.Map<List<MedicalTreatmentDto>>(medicalTreatments.registros);
            return new Pager<MedicalTreatmentDto>(lstMedicalTreatmentDto,medicalTreatments.totalRegistros,MedicalTreatmentParams.PageIndex,MedicalTreatmentParams.PageSize,MedicalTreatmentParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int Id)
        {
            var medicalTreatment = await _unitOfWork.MedicalTreatments.GetByIdAsync(Id);
            return Ok(medicalTreatment);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicalTreatment>> Post(MedicalTreatment MedicalTreatment)
        {
            _unitOfWork.MedicalTreatments.Add(MedicalTreatment);
            await _unitOfWork.SaveAsync();
            if (MedicalTreatment == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = MedicalTreatment.Id }, MedicalTreatment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<MedicalTreatment>> Put(int id, [FromBody] MedicalTreatment MedicalTreatment)
        {
            if (MedicalTreatment == null)
            {
                return NotFound();
            }
            _unitOfWork.MedicalTreatments.Update(MedicalTreatment);
            await _unitOfWork.SaveAsync();

            return MedicalTreatment;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var medicalTreatments = await _unitOfWork.MedicalTreatments.GetByIdAsync(id);
            if (medicalTreatments == null)
            {
                return NotFound();
            }
            _unitOfWork.MedicalTreatments.Remove(medicalTreatments);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }