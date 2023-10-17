namespace API.Dtos;
    public class FullPetDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public OwnerDto Owner {get;set;}
        public SpeciesNameDto Species {get;set;}
        public BreedDto Breed {get;set;}//raza
        public DateTime Birthdate {get;set;}

    }
