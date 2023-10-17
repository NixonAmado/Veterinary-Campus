using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;    public class OwnerPetDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public int PhoneNumber {get;set;}
        public List<PetStatDto> Pets {get;set;}
    }
