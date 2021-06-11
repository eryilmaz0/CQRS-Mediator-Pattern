using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolidPractice.Business.Abstract;
using SolidPractice.Business.Concrete;
using SolidPractice.DataAccess.EntityFramework;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }



        [HttpGet]
        [Route("{customerId:int}")]
        public IActionResult GetById(int customerId)
        {
            return Ok(_customerService.Get(x=>x.Id == customerId));
        }



        [HttpPost]
        public IActionResult AddCustomer(AddCustomerDto addCustomerDto)
        {
            var affectedRows = _customerService.Add(addCustomerDto);

            if (affectedRows == 0)
                return BadRequest("Müşteri Eklenemedi.");

            return Ok($"{affectedRows} Adet Müşteri Eklendi.");
        }



        [HttpDelete]
        [Route("{customerId:int}")]
        public IActionResult RemoveCustomer(int customerId)
        {
            var affectedRows = _customerService.Remove(customerId);

            if (affectedRows == 0)
                return BadRequest("Müşteri Silinemedi.");

            return Ok($"{affectedRows} Adet Müşteri Silindi.");


        }



        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var affectedRows = _customerService.Update(updateCustomerDto);

            if (affectedRows == 0)
                return BadRequest("Müşteri Güncellenemedi.");

            return Ok($"{affectedRows} Adet Müşteri Güncellendi.");
        }


    }
}
