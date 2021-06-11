using System.Linq;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;
using System.Threading;
using System.Threading.Tasks;
using SolidPractices.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.CommandHandlers
{
    public class RemoveAddressCommandHandler : ICommandRequestHandler<RemoveAddressCommandRequest, RemoveAddressCommandResponse>
    {
        public async Task<RemoveAddressCommandResponse> Handle(RemoveAddressCommandRequest request, CancellationToken cancellationToken)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                var address = _context.Addresses.FirstOrDefault(x => x.Id == request.Id);
                _context.Addresses.Remove(address);
                _context.SaveChanges();

                return new RemoveAddressCommandResponse();
            }
        }
    }
}