namespace SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address
{
    public class GetAllAddressesQueryResponse : QueryResponseBase
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


        public GetAllAddressesQueryResponse(bool isSuccess) : base(isSuccess)
        {

        }

        public GetAllAddressesQueryResponse():base()
        {
            
        }
    }
}