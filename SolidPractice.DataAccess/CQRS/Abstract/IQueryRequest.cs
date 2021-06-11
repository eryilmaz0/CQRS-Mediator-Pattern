using MediatR;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response;

namespace SolidPractice.DataAccess.CQRS.Abstract
{
    public interface IQueryRequest<TResponse> : IRequest<TResponse>
    {
        
    }
}