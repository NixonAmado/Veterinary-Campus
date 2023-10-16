using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OwnerDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int IdPersonTypeFk {get;set;}
        public PersonTypeDto PersonType {get;set;} 
        public string Email {get;set;}
        public int PhoneNumber {get;set;}
    }
}