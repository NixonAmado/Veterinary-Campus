using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AppointmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get() 
        {
            var appointments = await _unitOfWork.Appointments.GetAllAsync();
            return _mapper.Map<List<AppointmentDto>>(appointments);        
        }


        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<AppointmentDto>>> Get11([FromQuery] Params AppointmentParams )
        {
            var appointment = await _unitOfWork.Appointments.GetAllAsync(AppointmentParams.PageIndex,AppointmentParams.PageSize,AppointmentParams.Search);
            var lstAppointmentDto = _mapper.Map<List<AppointmentDto>>(appointment.registros);
            return new Pager<AppointmentDto>(lstAppointmentDto,appointment.totalRegistros,AppointmentParams.PageIndex,AppointmentParams.PageSize,AppointmentParams.Search);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Empleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppointmentDto>> Get(int Id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(Id);
            return _mapper.Map<AppointmentDto>(appointment);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Appointment>> Post(Appointment Appointment)
        {
            _unitOfWork.Appointments.Add(Appointment);
            await _unitOfWork.SaveAsync();
            if (Appointment == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = Appointment.Id }, Appointment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <ActionResult<Appointment>> Put(int id, [FromBody] Appointment Appointment)
        {
            if (Appointment == null)
            {
                return NotFound();
            }
            _unitOfWork.Appointments.Update(Appointment);
            await _unitOfWork.SaveAsync();

            return Appointment;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _unitOfWork.Appointments.Remove(appointment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }