using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name {get;set;}
        public int Stock {get;set;}
        public double Price {get;set;}
        public int IdLaboratoryFk {get;set;}
        public Laboratory Laboratory {get;set;}

        public ICollection<Person> Suppliers {get;set;} = new HashSet<Person>();
        public ICollection<ProductSupplier> ProductsSuppliers {get;set;}
        public ICollection<MedicalTreatment> MedicalTreatments {get;set;}
        public ICollection<ProductMovement> ProductMovements {get;set;}
        public ICollection<MovementDetail> MovementDetails {get;set;} 
    }
}