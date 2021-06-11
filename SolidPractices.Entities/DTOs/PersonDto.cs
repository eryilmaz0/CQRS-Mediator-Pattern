namespace SolidPractice.Entities.DTOs
{
    public abstract class PersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
    }
}