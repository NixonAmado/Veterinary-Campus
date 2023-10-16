using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicalTreatmentDto
    {
        public string Id {get;set;}
        public ProductDto Product {get;set;}
        public string Dose {get;set;}
        public DateTime AdministrationDate{get;set;}
        public string Observation {get;set;}
    
    }
}