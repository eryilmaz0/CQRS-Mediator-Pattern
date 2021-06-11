using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;

namespace SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address
{
    public class GetAddressByIdQueryRequest : IQueryRequest<GetAddressByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}