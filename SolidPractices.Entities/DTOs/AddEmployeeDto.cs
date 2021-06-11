namespace SolidPractice.Entities.DTOs
{
    public class AddEmployeeDto : PersonDto
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string ReportsTo { get; set; }
    }
}