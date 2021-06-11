using System.Collections.Generic;
using MediatR;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address
{
    public class GetAllAddressesQueryRequest : IQueryRequest<List<GetAllAddressesQueryResponse>>
    {
        
    }
}