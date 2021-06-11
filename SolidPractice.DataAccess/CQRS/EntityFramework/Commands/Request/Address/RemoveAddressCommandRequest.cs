using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address
{
    public class RemoveAddressCommandRequest : ICommandRequest<RemoveAddressCommandResponse>
    {
        public int Id { get; set; }
    }
}