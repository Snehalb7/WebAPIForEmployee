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
            var emp = _dbContext.Find<Employee>(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }


        //Add Employee details in DB
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee emp)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Set<Employee>().Add(emp);
            _dbContext.SaveChanges();
            return Ok(emp);
        }

        //Update Employee details in DB
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var empl = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (empl != null)
            {
                empl.EmpName = emp.EmpName;
                empl.Department = emp.Department;
                empl.Salary = emp.Salary;
                _dbContext.SaveChanges();
                return Ok("Employee updated Successfully");
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }
        //Delete Employee details in DB
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
                return Ok("Employee Deleted Successfully");
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }
        //Update only salary of Employee  in DB
        [HttpPatch]
        [Route("UpdateEmployeeFields/{id}")]
        public IActionResult UpdateEmployeeFields(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var emp = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                if (employee.Salary != 0)
                {
                    emp.Salary = employee.Salary;
                }
                emp.CreatedDate = DateTime.Now;
                _dbContext.SaveChanges();

                return Ok("Employee Salary updated successfully");
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }
    }

}
