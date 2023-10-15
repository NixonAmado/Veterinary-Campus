using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Breed : BaseEntity
    {
        public string Name { get; set; }
        public int IdSpeciesFk {get;set;}
        public Species Species {get;set;}
    }

}