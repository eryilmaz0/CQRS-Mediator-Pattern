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
    public class SuppliersController : ControllerBase
    {

        private readonly ISupplierService _supplierService;


        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_supplierService.GetAll());
        }



        [HttpGet]
        [Route("{supplierId:int}")]
        public IActionResult GetById(int supplierId)
        {
            var supplier = _supplierService.Get(x => x.Id == supplierId);

            if (supplier == null)
                return NoContent();

            return Ok(supplier);

        }





        [HttpPost]
        public IActionResult AddSupplier(AddSupplierDto addSupplierDto)
        {
            var affectedRows = _supplierService.Add(addSupplierDto);

            if (affectedRows == 0)
                return BadRequest("Tedarikçi Eklenemedi.");

            return Ok($"{affectedRows} Adet Tedarikçi Eklendi.");
        }




        [HttpPut]
        public IActionResult UpdateSupplier(UpdateSupplierDto updateSupplierDto)
        {
            var affectedRows = _supplierService.Update(updateSupplierDto);

            if (affectedRows == 0)
                return BadRequest("Tedarikçi Güncellenemedi.");

            return Ok($"{affectedRows} Adet Tedarikçi Güncellendi.");
        }




        [HttpDelete]
        [Route("{supplierId:int}")]
        public IActionResult RemoveSupplier(int supplierId)
        {
            var affectedRows = _supplierService.Remove(supplierId);

            if (affectedRows == 0)
                return BadRequest("Tedarikçi Silinemedi.");

            return Ok($"{affectedRows} Adet Tedarikçi Silindi.");

        }
    }
}
