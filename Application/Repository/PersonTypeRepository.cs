using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
    {
        private readonly DbAppContext _context;

        public PersonTypeRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }
