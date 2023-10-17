using System.Globalization;
using System.Reflection;
using CsvHelper;
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
        }    


//         1	nixon	nixonamado00@gmail.com	301851553	1,	
// 2	amado	amado@gmail.com	310851553	1,
// 3	carlos 	carlos@gmail.com	301242122	2	1,
// 4	Maria	Danzas@gmail.com	321321122	2	2,
// 5	Jose	Jose@gmail.com	321312312	3,	
// 6	Milton	militon@gmail.com	321312211	3,    
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