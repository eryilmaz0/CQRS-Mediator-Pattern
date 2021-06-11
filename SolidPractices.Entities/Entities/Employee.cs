namespace SolidPractices.Entities.Entities
{
    public class Employee : Person
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string ReportsTo { get; set; }

        
        public Employee():base()
        {
            
        }
    }
}