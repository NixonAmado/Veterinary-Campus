using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class VeterinarianDto
{
    public int Id {get;set;}
    public string Name {get;set;}
    public string Email {get;set;}
    public int PhoneNumber {get;set;}
    public EspecialityDto Especiality {get;set;}
}
