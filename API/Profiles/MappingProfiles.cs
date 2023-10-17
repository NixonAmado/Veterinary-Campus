using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Especiality, EspecialityDto>().ReverseMap();
        CreateMap<PersonType, PersonTypeDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Laboratory, LaboratoryDto>().ReverseMap();
        CreateMap<Species, SpeciesDto>().ReverseMap();
        CreateMap<Pet, FullPetDto>().ReverseMap();
        CreateMap<Pet, PetStatDto>().ReverseMap();
        
        CreateMap<Breed, BreedDto>().ReverseMap();
        CreateMap<CountBreed, CountBreedDto>().ReverseMap();
        CreateMap<BreedList, BreedListDto>().ReverseMap();

        CreateMap<MedicalTreatment, MedicalTreatmentDto>().ReverseMap();
        CreateMap<ProductMovement,ProductMovementDto>().ReverseMap();
        CreateMap<MovementDetail,MovementDetailDto>().ReverseMap();
        CreateMap<MovementType,MovementTypeDto>().ReverseMap();

        CreateMap<Person,SupplierDto>().ReverseMap();
        CreateMap<Person, VeterinarianDto>().ReverseMap();
        CreateMap<Person, OwnerDto>().ReverseMap();        
        CreateMap<Species, SpeciesDto>().ReverseMap();        
        CreateMap<Species, SpeciesNameDto>().ReverseMap();        
        
        //CreateMap<PersonType, TypePDto>().ReverseMap();

    }
}