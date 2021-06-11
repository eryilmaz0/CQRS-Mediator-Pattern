using MediatR;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;

namespace SolidPractice.DataAccess.CQRS.Abstract
{
    public interface ICommandRequest<TResponse> : IRequest<TResponse>
    {
        
    }
}