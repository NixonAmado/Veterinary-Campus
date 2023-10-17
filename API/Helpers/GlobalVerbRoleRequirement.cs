using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Helpers
{
    public class GlobalVerbRoleRequirement : IAuthorizationRequirement
    {
public bool IsAllowed(string role, string verb)
    {
        role = role.ToUpper();
        // allow all verbs if user is "Administrador"
        if(string.Equals("ADMINISTRADOR", role, StringComparison.OrdinalIgnoreCase)) return true;
        // allow the "GET" or "SET" verb if user is "Gerente"
        if (string.Equals("GERENTE", role, StringComparison.OrdinalIgnoreCase) && 
        (string.Equals("GET", verb, StringComparison.OrdinalIgnoreCase) || string.Equals("POST", verb, StringComparison.OrdinalIgnoreCase))) return true;

        // allow the "GET" verb if user is "Empleado"
        if(string.Equals("EMPLEADO", role, StringComparison.OrdinalIgnoreCase) && string.Equals("GET",verb, StringComparison.OrdinalIgnoreCase)){
            return true;
        };
        if(string.Equals("camper", role, StringComparison.OrdinalIgnoreCase) && string.Equals("GET",verb, StringComparison.OrdinalIgnoreCase)){
            return true;
        };
        // ... add other rules as you like
        return false;
    }        
    }
}