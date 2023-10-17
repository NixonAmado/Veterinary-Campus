using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupedSpecies : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Pet> Pets {get;set;}
    }

}