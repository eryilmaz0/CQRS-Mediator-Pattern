using System;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;
using System.Threading;
using System.Threading.Tasks;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.CommandHandlers
{
    public class CreateAddressCommandHandler : ICommandRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            
            using (var _context = new SolidPracticeDbContext())
            {
                var address = new Address() { Country = request.Country, City = request.City, PostCode = request.PostCode };
                _context.Addresses.Add(address);
                _context.SaveChanges();
                return new CreateAddressCommandResponse() { AddressId = address.Id };
            }

        }
    }
}