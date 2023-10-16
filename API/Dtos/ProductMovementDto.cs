using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductMovementDto
    {
        public ProductDto Product {get;set;}
        public int Quantity {get;set;}
        public DateTime Date{get;set;}
        public MovementTypeDto MovementType {get;set;} 
    }
}