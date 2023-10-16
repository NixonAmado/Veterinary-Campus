using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MovementDetailDto
 {
        public int Quantity {get;set;}
        public ProductMovementDto ProductMovement {get;set;}
        public double Price {get;set;}
    }
}