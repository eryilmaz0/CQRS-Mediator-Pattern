namespace SolidPractices.Entities.Entities
{
    public class Supplier : Person
    {
        public string CompanyName { get; set; }
        public string Fax { get; set; }


        public Supplier():base()
        {
            
        }
    }
}