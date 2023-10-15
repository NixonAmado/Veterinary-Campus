using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class EspecialityRepository : GenericRepository<Especiality>, IEspeciality
    {
        private readonly DbAppContext _context;

        public EspecialityRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }
