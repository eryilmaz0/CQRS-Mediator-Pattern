using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response;

namespace SolidPractice.DataAccess.CQRS.Abstract
{

    //Bu bir queryrequesthandler, haliyle verdiğin tresponse tipi queryresponsebase tipinden türeyen bir tip olmalı
    // TRequest tipi, generic olarak tresponse tipini barındıracak şekilde IQueryRequest tipini implemente etmiş olmalı

    public interface IQueryRequestHandler<TRequest,TResponse> : IRequestHandler<TRequest,TResponse>
                     where TRequest : IQueryRequest<TResponse>
    {
       
    }
}