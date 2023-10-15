using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMovement:BaseEntity
    {
        public int IdProductFk {get;set;}
        public double Quantity {get;set;}
        public DateTime Date{get;set;}
    }
}