using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Laboratory : BaseEntity
{
    public string Name {get;set;}
    public string  Address {get;set;}
    public int PhoneNumber{get;set;}
    public ICollection<Product> Products {get;set;}
}