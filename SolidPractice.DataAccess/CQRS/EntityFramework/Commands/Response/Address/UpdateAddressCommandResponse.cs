

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response
{
    public class UpdateAddressCommandResponse : CommandResponseBase
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


        public UpdateAddressCommandResponse(bool isSuccess) : base(isSuccess)
        {

        }

        public UpdateAddressCommandResponse():base()
        {
            
        }
    }
}