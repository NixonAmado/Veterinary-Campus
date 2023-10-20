using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PetStatDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Species {get;set;}
        public string Breed {get;set;}//raza
        public DateTime Birthdate {get;set;}
    }
}