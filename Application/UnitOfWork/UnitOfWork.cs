using Application.Repository;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly DbAppContext _context;
        private RoleRepository _roles;
        private UserRepository _users;
        private BreedRepository _breeds;
        private AppointmentRepository _appointment;
        private EspecialityRepository _especialities;
        private LaboratoryRepository _laboratories;
        private MedicalTreatmentRepository _medicalTreatments;
        private MovementDetailRepository _movementDetails;
        private MovementTypeRepository _movementTypes;
        private PersonRepository _people;
        private PersonTypeRepository _personTypes;
        private PetRepository _pets;
        private ProductRepository _products;
        private ProductMovementRepository _productMovements;
        private RefreshTokenRepository _refreshTokens;
        private SpeciesRepository _species;

        public UnitOfWork(DbAppContext context)
        {
            _context = context;
        }

        public IRole Roles
        {
            get
            {
                if(_roles == null)
                {
                    _roles = new RoleRepository(_context);
                }
                return _roles;
            }
        }
        public IUser Users{
            get{
                if(_users == null)
                {
                    _users = new UserRepository(_context); 
                }
                return _users;
            }
        }
        public IAppointment Appointments{
            get{
                if(_appointment == null)
                {
                    _appointment = new AppointmentRepository(_context); 
                }
                return _appointment;
            }
        }
        public IBreed Breeds{
            get{
                if(_breeds == null)
                {
                    _breeds = new BreedRepository(_context); 
                }
                return _breeds;
            }
        }
        public IEspeciality Especialities{
            get{
                if(_especialities == null)
                {
                    _especialities = new EspecialityRepository(_context); 
                }
                return _especialities;
            }
        }
        public ILaboratory Laboratories{
            get{
                if(_laboratories == null)
                {
                    _laboratories = new LaboratoryRepository(_context); 
                }
                return _laboratories;
            }
        }

        public IMedicalTreatment MedicalTreatments{
            get{
                if(_medicalTreatments == null)
                {
                    _medicalTreatments = new MedicalTreatmentRepository(_context); 
                }
                return _medicalTreatments;
            }
        }
        public IMovementDetail MovementDetails{
            get{
                if(_movementDetails == null)
                {
                    _movementDetails = new MovementDetailRepository(_context); 
                }
                return _movementDetails;
            }
        }
        public IMovementType MovementTypes{
            get{
                if(_movementTypes == null)
                {
                    _movementTypes = new MovementTypeRepository(_context); 
                }
                return _movementTypes;
            }
        }
        public IPerson People{
            get{
                if(_people == null)
                {
                    _people = new PersonRepository(_context); 
                }
                return _people;
            }
        }
        public IPersonType PersonTypes{
            get{
                if(_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context); 
                }
                return _personTypes;
            }
        }
        public IPet Pets{
            get{
                if(_pets == null)
                {
                    _pets = new PetRepository(_context); 
                }
                return _pets;
            }
        }
        public IProduct Products{
            get{
                if(_products == null)
                {
                    _products = new ProductRepository(_context); 
                }
                return _products;
            }
        }
        public ISpecies Species{
            get{
                if(_species == null)
                {
                    _species = new SpeciesRepository(_context); 
                }
                return _species;
            }
        }
        public IProductMovement ProductMovements{
            get{
                if(_productMovements == null)
                {
                    _productMovements = new ProductMovementRepository(_context); 
                }
                return _productMovements;
            }
        }
        public IRefreshToken RefreshTokens{
            get{
                if(_refreshTokens == null)
                {
                    _refreshTokens = new RefreshTokenRepository(_context); 
                }
                return _refreshTokens;
            }
        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}