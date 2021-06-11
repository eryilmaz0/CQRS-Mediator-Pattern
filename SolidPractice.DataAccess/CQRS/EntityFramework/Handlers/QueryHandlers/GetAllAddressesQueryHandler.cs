using System;
using System.Collections.Generic;
using System.Linq;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolidPractices.Entities;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.QueryHandlers
{
    public class GetAllAddressesQueryHandler : IQueryRequestHandler<GetAllAddressesQueryRequest, List<GetAllAddressesQueryResponse>>
    {
        public async Task<List<GetAllAddressesQueryResponse>> Handle(GetAllAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            using (var _context = new SolidPracticeDbContext())
            {
                return  _context.Addresses.Select(x => new GetAllAddressesQueryResponse()
                {
                    Id = x.Id,
                    Country = x.Country,
                    City = x.City,
                    PostCode = x.PostCode
                }).ToList();
            }
        }
    }
}