using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace CQRSBusiness.Abstract
{
    public interface IAddressService
    {
        Task<IList<GetAllAddressesQueryResponse>> GetAll(GetAllAddressesQueryRequest requestModel);
        Task<GetAddressByIdQueryResponse> GetById(GetAddressByIdQueryRequest requestModel);
        Task<CreateAddressCommandResponse> Add(CreateAddressCommandRequest requestModel);
        Task<RemoveAddressCommandResponse> Remove(RemoveAddressCommandRequest requestModel);
        Task<UpdateAddressCommandResponse> Update(UpdateAddressCommandRequest requestModel);
    }
}