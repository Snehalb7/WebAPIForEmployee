using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForEmployee.Models;
using System.Collections.Generic;

namespace WebAPIForEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private readonly MyDbContext _dbContext;
       

        public EmployeeController(MyDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetAllEmployee()
        {
           var employees = _dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp=_dbContext.Find<Employee>(id);
            if(emp==null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee emp)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Set<Employee>().Add(emp);
            _dbContext.SaveChanges();
            return Ok(emp);
        }
    }

}
