using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolidPractice.Business.Abstract;
using SolidPractice.Entities.DTOs;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_addressService.GetAll());
        }



        [HttpGet]
        [Route("{addressId:int}")]
        public IActionResult GetById(int addressId)
        {
            var address = _addressService.Get(x => x.Id == addressId);

            if (address == null)
                return NotFound("Adres Bulunamadı.");

            return Ok(address);
        }
        

        [HttpPost]
        public IActionResult AddAddress(AddAddressDto addressDto)
        {
            var affectedRows = _addressService.Add(addressDto);

            if (affectedRows == 0)
            {
                return BadRequest("Adres Eklenemedi.");
            }

            return Ok($"{affectedRows} Adet Adres Eklendi.");
        }




        [HttpDelete]
        [Route("{addressId:int}")]
        public IActionResult RemoveAddress(int addressId)
        {
            var affectedRows = _addressService.Remove(addressId);

            if (affectedRows == 0)
                return BadRequest("Adres Silinemedi.");

            return Ok($"{affectedRows} Adet Adres Silindi.");
        }





        [HttpPut]
        public IActionResult UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            var affectedRows = _addressService.Update(updateAddressDto);

            if (affectedRows == 0)
                return BadRequest("Adres Güncellenemedi.");

            return Ok($"{affectedRows} Adet Adres Güncellendi.");
        }

    }
}
