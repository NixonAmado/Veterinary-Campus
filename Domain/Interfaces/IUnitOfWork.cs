using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRole Roles {get;}
        public IUser Users {get;}
        public IAppointment Appointments {get;}
        public IBreed Breeds {get;}
        public IEspeciality Especialities {get;}
        public ILaboratory Laboratories {get;}
        public IMedicalTreatment MedicalTreatments {get;}
        public IMovementDetail MovementDetails {get;}
        public IMovementType MovementTypes {get;}
        public IPerson People {get;}
        public IPersonType PersonTypes {get;}
        public IPet Pets {get;}
        public IProduct Products {get;}
        public IProductMovement ProductMovements {get;}
        public IRefreshToken RefreshTokens {get;}
        public ISpecies Species {get;}
        Task<int> SaveAsync();
    }
}