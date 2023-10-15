using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Veterinarian : BaseEntity
{
    public string Name {get;set;}
    public string Email {get;set;}
    public int PhoneNumber {get;set;}
    public string Especiality {get;set;}
}
