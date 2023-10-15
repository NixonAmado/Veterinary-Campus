using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MovementDetail:BaseEntity
    {
        public int IdProductFk {get;set;}
        public Product Product {get;set;}
        public int Quantity {get;set;}
        public int IdProdMovementFk {get;set;}
        public ProductMovement ProductMovements {get;set;}
        public double Price {get;set;}
    }
}