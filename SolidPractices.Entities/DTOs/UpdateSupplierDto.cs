using System.Reflection.Metadata.Ecma335;

namespace SolidPractice.Entities.DTOs
{
    public class UpdateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }

    }
}