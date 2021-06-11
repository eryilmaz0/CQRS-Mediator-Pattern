using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolidPractice.Business.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;


        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }



        [HttpGet]
        [Route("{employeeId:int}")]
        public IActionResult GetById(int employeeId)
        {
            var employee = _employeeService.Get(x => x.Id == employeeId);

            if (employee == null)
                return NotFound("Personel Bulunamadı.");

            return Ok(employee);
        }





        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var affectedRows = _employeeService.Add(addEmployeeDto);

            if (affectedRows == 0)
                return BadRequest("Personel Eklenemedi.");

            return Ok($"{affectedRows} Adet Personel Eklendi.");
        }




        [HttpPut]
        public IActionResult UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var affectedRows = _employeeService.Update(updateEmployeeDto);

            if (affectedRows == 0)
                return BadRequest("Personel Güncellenemedi.");

            return Ok($"{affectedRows} Adet Personel Güncellendi.");
        }




        [HttpDelete]
        [Route("{employeeId:int}")]
        public IActionResult DeleteEmploye(int employeeId)
        {
            var affectedRows = _employeeService.Remove(employeeId);

            if (affectedRows == 0)
                return BadRequest("Personel Silinemedi.");

            return Ok($"{affectedRows} Adet Personel Silindi.");
        }
    }
}
