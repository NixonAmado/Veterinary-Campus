namespace API.Dtos
{
    public class SpeciesDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public List<PetStatDto> Pets {get;set;}
    }
}