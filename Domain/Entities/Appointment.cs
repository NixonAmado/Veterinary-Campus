using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment: BaseEntity
    {
        public int IdPetFk {get;set;}
        public Pet Pet {get;set;}
        public DateTime Date {get;set;}
        public double Hour {get;set;}
        public string Reason {get;set;}
    }
}