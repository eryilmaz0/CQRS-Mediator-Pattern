namespace SolidPractice.Entities.DTOs
{
    public class AddSupplierDto : PersonDto
    {
        public string CompanyName { get; set; }
        public string Fax { get; set; }
    }
}