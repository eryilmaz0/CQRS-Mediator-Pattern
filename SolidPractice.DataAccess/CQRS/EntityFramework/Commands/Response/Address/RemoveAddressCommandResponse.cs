namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address
{
    public class RemoveAddressCommandResponse : CommandResponseBase
    {
        //

        public RemoveAddressCommandResponse(bool isSuccess) : base(isSuccess)
        {

        }

        public RemoveAddressCommandResponse():base()
        {
            
        }
    }
}