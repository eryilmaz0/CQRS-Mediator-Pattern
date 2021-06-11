namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address
{
    public class CreateAddressCommandResponse :CommandResponseBase
    {
        public int AddressId { get; set; }


        public CreateAddressCommandResponse(bool isSuccess):base(isSuccess)
        {
            
        }

        public CreateAddressCommandResponse():base()
        {
            
        }
    }
}