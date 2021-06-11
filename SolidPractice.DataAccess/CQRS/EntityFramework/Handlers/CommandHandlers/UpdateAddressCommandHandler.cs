using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;
using SolidPractices.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.CommandHandlers
{
    public class UpdateAddressCommandHandler : ICommandRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                var address = _context.Addresses.FirstOrDefault(x => x.Id == request.Id);

                address.Country = request.Country;
                address.City = request.City;
                address.PostCode = request.PostCode;

                _context.Addresses.Update(address);
                _context.SaveChanges();

                return new UpdateAddressCommandResponse()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City,
                    PostCode = address.PostCode
                };
            }
        }
    }
}