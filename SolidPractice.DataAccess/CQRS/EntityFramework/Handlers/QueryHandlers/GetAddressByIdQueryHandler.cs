using System.Linq;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolidPractices.Entities;
using SolidPractices.Entities.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.QueryHandlers
{
    public class GetAddressByIdQueryHandler : IQueryRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
    {

        public async Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                var address = _context.Addresses.Include(x=>x.Customer).FirstOrDefault(x => x.Id == request.Id);

                return new GetAddressByIdQueryResponse()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City,
                    PostCode = address.PostCode,
                    Created = address.Created,
                    Customer = address.Customer
                };
            }
        }
    }
}