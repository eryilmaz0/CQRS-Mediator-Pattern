namespace SolidPractices.Entities.Entities
{
    public class Address : EntityBase
    {
        
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Supplier Supplier { get; set; }

        public Address():base()
        {
            
        }
    }
}