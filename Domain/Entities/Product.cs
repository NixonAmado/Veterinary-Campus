using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name {get;set;}
        public int QuantityAvailable {get;set;}
        public double Price {get;set;}
        public int IdLaboratoryFk {get;set;}
        public Laboratory Laboratory {get;set;}
    
    }
}