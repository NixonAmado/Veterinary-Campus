using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly DbAppContext _context;

        public PersonRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        /*======================================== Veterinario ===========================================================*/
        //Crear un consulta que permita visualizar los veterinarios cuya especialidad sea X. -- OK
        public async Task<IEnumerable<Person>> GetVetByEspecialityAsync(string Especiality)
        {
            return await _context.People
                                .Where( p => p.PersonType.Description.ToUpper() == "VETERINARIO" &&
                                p.Especiality.Description.ToUpper() == Especiality.ToUpper())
                                .Include(p => p.Especiality)
                                .ToListAsync();
        }
        //Listar las mascotas que fueron atendidas por un determinado veterinario.--Ok
        public async Task<IEnumerable<Pet>> PetsAttendedByVet(string veterinarian)
        {
            return await _context.People
                                .Where( p => p.PersonType.Description.ToUpper() == "VETERINARIO" &&
                                p.Appointments.Any(ap => ap.Veterinarian.Name.ToUpper() == veterinarian.ToUpper()))
                                .SelectMany(p => p.Appointments.Select(ap => ap.Pet))                                
                                .Include(p => p.Breed)
                                .Include(p => p.Species)
                                .ToListAsync();
        }
        
    /*======================================== Propietario ===========================================================*/

    //Listar los propietarios y sus mascotas.--OK
    public async Task<IEnumerable<Person>> GetAllOwnersAndPets ()
    {
        return await _context.People
                            .Where(p => p.PersonType.Description.ToUpper() == "PROPIETARIO")
                            .Include(p => p.Pets).ThenInclude(p => p.Breed).ThenInclude(p => p.Species)
                            .ToListAsync();
    }
    /*======================================== Proovedor ===========================================================*/
    //Listar los proveedores que me venden un determinado medicamento.--OK
    public async Task<IEnumerable<Person>> GetSuppliersByProduct(string product)
    {
        return await _context.People
                            .Where(p => p.PersonType.Description.ToUpper() == "PROOVEDOR" &&
                            p.ProductsSuppliers.Any(p => p.Product.Name.ToLower() == product.ToLower()))
                            .SelectMany(p => p.ProductsSuppliers.Select(p => p.Supplier).Distinct())
                            .ToListAsync();
    }
    

    //==============================================================================================================}
    public async Task<IEnumerable<Person>> GetAllOwnersAsync()
    {
        return await _context.People
                            .Where(p => p.PersonType.Description.ToLower() == "PROPIETARIO")
                            .ToListAsync();
    }
        public async Task<IEnumerable<Person>> GetAllVeterinarianAsync()
    {
        return await _context.People
                            .Where(p => p.PersonType.Description.ToLower() == "VETERINARIO")
                            .ToListAsync();
    }
        public async Task<IEnumerable<Person>> GetAllSuppliersAsync()
    {
        return await _context.People
                            .Where(p => p.PersonType.Description.ToLower() == "PROOVEDOR")
                            .ToListAsync();
    }

    }
