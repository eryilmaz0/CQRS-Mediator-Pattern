namespace SolidPractice.Entities.DTOs
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string ReportsTo { get; set; }
    }
}