using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Pet: BaseEntity
    {
        public int IdOwnerFk{get;set;}
        public User User {get;set;}
        public int IdSpeciesFk{get;set;}
        public Species Species {get;set;}
        public int IdBreedFk{get;set;}
        public Breed Breed {get;set;}//raza
        public string Name {get;set;}
        public DateTime Birthdate {get;set;}
    }
