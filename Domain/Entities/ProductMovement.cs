using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMovement : BaseEntity
    {
        public int IdProductFk {get;set;}
        public Product Product {get;set;}
        public double TotalPrice {get;set;}
        public int Quantity {get;set;}
        public DateTime Date{get;set;}
        public ICollection<MovementDetail> MovementDetails {get;set;}
    }
}