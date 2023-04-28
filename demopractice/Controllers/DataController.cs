namespace demopractice.Controllers
{
    using BusinessLayer.Service;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        public DataController (IEmployeeRepository employeeRepository ,IEmployeeService employeeService )
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        [Authorize]
        [HttpGet("GetEmployeeById")]
        public Employee GetById(int Id)
        {
            var data = _employeeService.GetPersonByUserId(Id);
            return data;
        }
        [Authorize]
        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAll()
        {
            var data = _employeeService.GetEmployees();
            return data;
        }
        [Authorize]
        [HttpPost("AddEmployee")]
        public async Task<Employee> AddPerson([FromBody] Employee employee)
        {            
            return await _employeeService.AddEmployee(employee);
        }
        [Authorize]
        [HttpDelete("DeleteEmployee")]
        public bool DeleteEmployee(int Id)
        {
            _employeeService.deleteEmployee(Id);
            return true;
        }
        [Authorize]
        [HttpPut("UpdateEmployee")]
        public bool UpdateEmployee([FromBody] Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return true;
        }
    }
}
