using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public List<Employee> GetAllEmployee() 
        {
            return _employeeService.GetEmployeeDetails();
        }

        [HttpGet("GetEmployeeById")]
        public Employee GetEmployeeById(int id)
        {
            return _employeeService.GetEmployee(id);
        }


        [HttpPost("AddEmployee")]
        public Employee AddEmployee(Employee employee)
        {
            return _employeeService.AddEmployee(employee);
        }

        [HttpPost("UpdateEmployee")]
        public void UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
        }


        [HttpGet("DeleteEmployee")]
        public Employee DeleteEmployee(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }
        
    }
}
