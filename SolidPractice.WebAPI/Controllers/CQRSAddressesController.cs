using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSBusiness.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Commands.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CQRSAddressesController : ControllerBase
    {

        private readonly IAddressService _addressService;


        public CQRSAddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAddressesQueryRequest requestModel)
        {
            var addresses = await _addressService.GetAll(requestModel);

            if (addresses.Count == 0)
                return NoContent();

            return Ok(addresses);
        }



        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> GetById([FromQuery] GetAddressByIdQueryRequest requestModel)
        {
            var address = await _addressService.GetById(requestModel);

            if (address == null)
                return NoContent();

            return Ok(address);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommandRequest requestModel)
        {
            var createResult = await _addressService.Add(requestModel);

            if (createResult.IsSuccess)
                return Ok($"Adres Başarıyla Eklendi. (Id : {createResult.AddressId} )");

            return BadRequest("Adres Silinemedi.");
        }



        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommandRequest requestModel)
        {
            var updateResult = await _addressService.Update(requestModel);

            if (updateResult.IsSuccess)
                return Ok(updateResult);

            return BadRequest("Adres Güncellenemedi.");
        }



        [HttpDelete]
        public async Task<IActionResult> RemoveAddress([FromQuery] RemoveAddressCommandRequest requestModel)
        {
            var removeResult = await _addressService.Remove(requestModel);

            if (removeResult.IsSuccess)
                return Ok(removeResult);

            return BadRequest("Adres Silinemedi.");
        }
    }
}
