using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly DbAppContext _context;

        public PersonRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }
