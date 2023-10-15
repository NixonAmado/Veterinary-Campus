using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        public string Name {get;set;}
        public string Email {get;set;}
        public int PhoneNumber {get;set;}
        public int IdPersonTypeFk {get;set;}
        public PersonType PersonType {get;set;}
        public int? IdEspecialityFk {get;set;}
        public Especiality? Especiality {get;set;}

        public ICollection<Pet> Pets {get;set;}
        public ICollection<Appointment> Appointments {get;set;}
        public ICollection<Product> Products {get;set;} = new HashSet<Product>();
        public ICollection<ProductSupplier> ProductsSuppliers {get;set;}

    }
}