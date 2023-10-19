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
                using (var readerPersonTypes = new StreamReader("../Persistence/Data/Csvs/PersonType.csv"))
                {
                    using (var csv = new CsvReader(readerPersonTypes, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<PersonType>();
                        context.PersonTypes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
             
            if (!context.Especialities.Any())
            {
                using (var Especiality = new StreamReader("../Persistence/Data/Csvs/Especiality.csv"))
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
                using (var Laboratory = new StreamReader("../Persistence/Data/Csvs/Laboratory.csv"))
                {
                    using (var csv = new CsvReader(Laboratory, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratory>();
                        context.Laboratories.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            
                                                      
            if (!context.MovementTypes.Any())
            {
                using (var MovementType = new StreamReader("../Persistence/Data/Csvs/MovementType.csv"))
                {
                    using (var csv = new CsvReader(MovementType, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<MovementType>();
                        context.MovementTypes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.Species.Any())
            {
                using (var Species = new StreamReader("../Persistence/Data/Csvs/Species.csv"))
                {
                    using (var csv = new CsvReader(Species, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Species>();
                        context.Species.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }    
            }
            if (!context.People.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Person.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Person>();
                        List<Person> entidad = new List<Person>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Person
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Email = item.Email,
                                PhoneNumber = item.PhoneNumber,
                                IdPersonTypeFk = item.IdPersonTypeFk,
                                IdEspecialityFk = item.IdEspecialityFk,
                            });
                        }
                        context.People.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }   
            if (!context.Breeds.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Breed.csv"))
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
            if (!context.Pets.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Pet.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Pet>();
                        List<Pet> entidad = new List<Pet>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Pet
                            {
                                Id = item.Id,
                                Name = item.Name,
                                IdOwnerFk = item.IdOwnerFk,
                                IdSpeciesFk = item.IdSpeciesFk,
                                IdBreedFk = item.IdBreedFk,
                                Birthdate = item.Birthdate,
                            });
                        }
                        context.Pets.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Appointments.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Appointment.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Appointment>();
                        List<Appointment> entidad = new List<Appointment>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Appointment
                            {
                                Id = item.Id,
                                IdPetFk = item.IdPetFk,
                                Date = item.Date,
                                Hour = item.Hour,
                                Reason = item.Reason,
                                IdVeterinarianFk = item.IdVeterinarianFk,
                            });
                        }
                        context.Appointments.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
             if (!context.Products.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Product.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Product>();
                        List<Product> entidad = new List<Product>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Product
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Stock = item.Stock,
                                Price = item.Price,
                                IdLaboratoryFk = item.IdLaboratoryFk,
                            });
                        }
                        context.Products.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }            
            if (!context.MedicalTreatments.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/MedicalTreatment.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MedicalTreatment>();
                        List<MedicalTreatment> entidad = new List<MedicalTreatment>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicalTreatment
                            {
                                Id = item.Id,
                                IdAppointmentFk = item.IdAppointmentFk,
                                IdProductFk = item.IdProductFk,
                                Dose = item.Dose,
                                AdministrationDate = item.AdministrationDate,
                                Observation = item.Observation

                            });
                        }
                        context.MedicalTreatments.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.MovementDetails.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/MovementDetail.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MovementDetail>();
                        List<MovementDetail> entidad = new List<MovementDetail>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MovementDetail
                            {
                                Id = item.Id,
                                IdMovementTypeFk = item.IdMovementTypeFk,
                                IdProductFk = item.IdProductFk,
                                Quantity = item.Quantity,
                                Price = item.Price
                            });
                        }
                        context.MovementDetails.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }                        
            if (!context.ProductMovements.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/ProductMovement.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<ProductMovement>();
                        List<ProductMovement> entidad = new List<ProductMovement>();
                        foreach (var item in list)
                        {
                            entidad.Add(new ProductMovement
                            {
                                Id = item.Id,
                                IdProductFk = item.IdProductFk,
                                TotalPrice = item.TotalPrice,
                                Quantity = item.Quantity,
                                Date = item.Date,
                            });
                        }
                        context.ProductMovements.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }                                    
            if (!context.ProductSuppliers.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/ProductSupplier.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<ProductSupplier>();
                        List<ProductSupplier> entidad = new List<ProductSupplier>();
                        foreach (var item in list)
                        {
                            entidad.Add(new ProductSupplier
                            {
                                IdProductFk = item.IdProductFk,
                                IdSupplierFk = item.IdSupplierFk,

                            });
                        }
                        context.ProductSuppliers.AddRange(entidad);
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