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
        public SpeciesNameDto Species {get;set;}
        public BreedDto Breed {get;set;}//raza
        public DateTime Birthdate {get;set;}
    }
}