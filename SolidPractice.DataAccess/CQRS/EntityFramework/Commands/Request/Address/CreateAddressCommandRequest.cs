using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address
{
    public class CreateAddressCommandRequest : ICommandRequest<CreateAddressCommandResponse>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
