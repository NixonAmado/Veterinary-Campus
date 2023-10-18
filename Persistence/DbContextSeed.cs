using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistencia.Data;

namespace Persistence;
public class DbAppContextSeed
{

    public static async Task SeedAsync(DbAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

              if (!context.PersonTypes.Any())
            {
                using (var readerPersonTypes = new StreamReader(ruta + @"/Data/Csvs/PersonTtype.csv"))
                {
                    using (var csv = new CsvReader(readerPersonTypes, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<PersonType>();
                        context.PersonTypes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
              if (!context.People.Any())
            {
                using (var Person = new StreamReader(ruta + @"/Data/Csvs/Person.csv"))
                {
                    using (var csv = new CsvReader(Person, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Person>();
                        context.People.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
              if (!context.Appointments.Any())
            {
                using (var Appointment = new StreamReader(ruta + @"/Data/Csvs/Appointment.csv"))
                {
                    using (var csv = new CsvReader(Appointment, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Appointment>();
                        context.Appointments.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }     
            if (!context.Breeds.Any())
            {
                using (var Breed = new StreamReader(ruta + @"/Data/Csvs/Breed.csv"))
                {
                    using (var csv = new CsvReader(Breed, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Breed>();
                        context.Breeds.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Especialities.Any())
            {
                using (var Especiality = new StreamReader(ruta + @"/Data/Csvs/Especiality.csv"))
                {
                    using (var csv = new CsvReader(Especiality, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Especiality>();
                        context.Especialities.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Laboratories.Any())
            {
                using (var Laboratory = new StreamReader(ruta + @"/Data/Csvs/Laboratory.csv"))
                {
                    using (var csv = new CsvReader(Laboratory, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratory>();
                        context.Laboratories.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.MedicalTreatments.Any())
            {
                using (var MedicalTreatment = new StreamReader(ruta + @"/Data/Csvs/MedicalTreatment.csv"))
                {
                    using (var csv = new CsvReader(MedicalTreatment, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<MedicalTreatment>();
                        context.MedicalTreatments.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }  
            if (!context.MovementDetails.Any())
            {
                using (var MovementDetail = new StreamReader(ruta + @"/Data/Csvs/MovementDetail.csv"))
                {
                    using (var csv = new CsvReader(MovementDetail, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<MovementDetail>();
                        context.MovementDetails.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }                                             
            if (!context.MovementTypes.Any())
            {
                using (var MovementType = new StreamReader(ruta + @"/Data/Csvs/MovementType.csv"))
                {
                    using (var csv = new CsvReader(MovementType, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<MovementType>();
                        context.MovementTypes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Pets.Any())
            {
                using (var Pet = new StreamReader(ruta + @"/Data/Csvs/Pet.csv"))
                {
                    using (var csv = new CsvReader(Pet, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Pet>();
                        context.Pets.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Products.Any())
            {
                using (var Products = new StreamReader(ruta + @"/Data/Csvs/Products.csv"))
                {
                    using (var csv = new CsvReader(Products, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Product>();
                        context.Products.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.ProductMovements.Any())
            {
                using (var ProductMovement = new StreamReader(ruta + @"/Data/Csvs/ProductMovement.csv"))
                {
                    using (var csv = new CsvReader(ProductMovement, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<ProductMovement>();
                        context.ProductMovements.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }

            if (!context.ProductsSuppliers.Any())
            {
                using (var MedicalTreatment = new StreamReader(ruta + @"/Data/Csvs/MedicalTreatment.csv"))
                {
                    using (var csv = new CsvReader(MedicalTreatment, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<ProductSupplier>();
                        context.ProductsSuppliers.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Species.Any())
            {
                using (var Species = new StreamReader(ruta + @"/Data/Csvs/Species.csv"))
                {
                    using (var csv = new CsvReader(Species, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Species>();
                        context.Species.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Breeds.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Medicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Breed>();
                        List<Breed> entidad = new List<Breed>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Breed
                            {
                                Id = item.Id,
                                Name = item.Name,
                                IdSpeciesFk = item.IdSpeciesFk
                            });
                        }
                        context.Breeds.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }    

// Id,Name,Email,PhoneNumber,IdPersonTypeFk,IdEspecialityFk
// 1,nixon,nixonamado00@gmail.com,301851553,1	
// 2,amado,amado@gmail.com,310851553,1
// 3,carlos,carlos@gmail.com,301242122,2,1
// 4,Maria,Danzas@gmail.com,321321122,2,2
// 5,Jose,Jose@gmail.com,321312312,3,	
// 6,Milton,militon@gmail.com,21312211,3    
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<DbAppContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(DbAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                        {
                            new Role{Id=1, Description="Administrador"},
                            new Role{Id=6, Description="Gerente"},
                            new Role{Id=2, Description="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<DbAppContext>();
            logger.LogError(ex.Message);
        }
    }
}