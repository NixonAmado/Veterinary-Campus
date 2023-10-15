using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class MedicalTreatment :BaseEntity
    {
        public int IdAppointmentFk {get;set;}
        public Appointment Appointment { get; set; } 
        public string Dose {get;set;}
        public DateTime AdministrationDate{get;set;}
        public string observation {get;set;}
    }