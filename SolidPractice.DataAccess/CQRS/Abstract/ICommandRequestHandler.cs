using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;

namespace SolidPractice.DataAccess.CQRS.Abstract
{
   
    //Bu commandhandler sınıflarının kullanacağı interface. Haliyle tresponse bir commandresponsebase olmalı
    //Aynı zamanda verdiğin trequest tipi, generic olarak burada verdiğin tresponse tipini barındırmalı ki tipler uyuşsun.

    public interface ICommandRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
                     where TRequest : ICommandRequest<TResponse> 
        
    {
        
    }
}