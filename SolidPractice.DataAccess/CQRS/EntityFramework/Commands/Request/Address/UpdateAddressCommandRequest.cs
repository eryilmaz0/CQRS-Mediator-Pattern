using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address
{
    public class UpdateAddressCommandRequest : ICommandRequest<UpdateAddressCommandResponse>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}