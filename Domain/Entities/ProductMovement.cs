using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMovement:BaseEntity
    {
        public int IdProductFk {get;set;}
        public int Quantity {get;set;}
        public DateTime Date{get;set;}
        public int IdMovementTypeFk {get;set;}
        public MovementType MovementType {get;set;} 
        public ICollection<MovementDetail> MovenmentDetail {get;set;}
    }
}