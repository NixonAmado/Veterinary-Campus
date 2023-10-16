using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AppointmentDto
    {
        public int Id {get;set;}
        public PetDto Pet {get;set;}
        public DateTime Date {get;set;}
        public double Hour {get;set;}
        public string Reason {get;set;}
        public VeterinarianDto Veterinarian {get;set;}
        public List<MedicalTreatmentDto> MedicalTreatments {get;set;}
    }
}