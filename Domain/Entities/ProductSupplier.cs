using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class ProductSupplier
    {
        public int IdSupplierFk {get;set;}
        public Person Supplier {get;set;}   
        public int IdProductFk {get;set;}
        public Product Product {get;set;}   
    }
