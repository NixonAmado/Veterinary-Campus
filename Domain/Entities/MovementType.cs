using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovementType: BaseEntity
    {
        public string Description {get;set;}
        public ICollection<Product> Products {get;set;}
    }
}