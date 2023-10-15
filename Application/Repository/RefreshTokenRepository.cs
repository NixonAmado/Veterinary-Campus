using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
    {
        private readonly DbAppContext _context;

        public RefreshTokenRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }
