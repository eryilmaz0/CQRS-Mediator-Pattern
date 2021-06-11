using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSBusiness.Abstract;
using MediatR;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Response.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace CQRSBusiness.Concrete
{
    public class AddressManager : IAddressService
    {

        private readonly IMediator _mediator;


        public AddressManager(IMediator mediator)
        {
            _mediator = mediator;
        }


        //Her service methotu içerisinde iş kuralları yürütülebilir
        public async Task<IList<GetAllAddressesQueryResponse>> GetAll(GetAllAddressesQueryRequest requestModel)
        {
            List<GetAllAddressesQueryResponse> allAddresses = await _mediator.Send(requestModel);
            return allAddresses;
        }


        public async Task<GetAddressByIdQueryResponse> GetById(GetAddressByIdQueryRequest requestModel)
        {
            GetAddressByIdQueryResponse address = await _mediator.Send(requestModel);
            return address;
        }


        public async Task<CreateAddressCommandResponse> Add(CreateAddressCommandRequest requestModel)
        {
            CreateAddressCommandResponse createResult = await _mediator.Send(requestModel);
            return createResult;
        }


        public async Task<RemoveAddressCommandResponse> Remove(RemoveAddressCommandRequest requestModel)
        {
            RemoveAddressCommandResponse removeResponse = await _mediator.Send(requestModel);
            return removeResponse;
        }


        public async Task<UpdateAddressCommandResponse> Update(UpdateAddressCommandRequest requestModel)
        {
            UpdateAddressCommandResponse updateResponse = await _mediator.Send(requestModel);
            return updateResponse;
        }
    }
}