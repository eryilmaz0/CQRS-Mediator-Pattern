namespace SolidPractices.Entities.Entities
{
    //BU PROJEDE PERSON SOYUT BİR KAVRAM.
    //PERSON İLE İŞLEM YAPMAK İÇİN CUSTOMER,EMPLOYEE VEYA SUPPLIER OLSUN İSTERİZ
    public abstract class Person : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }


        //NAV PROP.
        public Address Address { get; set; }



        public Person():base()
        {
            
        }
    }
}