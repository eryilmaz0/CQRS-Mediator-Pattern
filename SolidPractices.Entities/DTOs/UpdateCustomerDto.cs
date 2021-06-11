namespace SolidPractice.Entities.DTOs
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string CustomerType { get; set; }
    }
}