namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Threading.Tasks;
    using DataAccessLayer.DATA;

    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(IEmployeeRepository employeeRepository, ApplicationDbContext applicationDbContext)
        {
            _employeeRepository = employeeRepository;
            _dbContext = applicationDbContext;
        }
        //Get Person Details By Person Id  
        public Employee GetPersonByUserId(int Id)
        {
            return _employeeRepository.GetById(Id);
        }
        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAllEmployee().ToList();
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }

        public bool deleteEmployee(int Id)
        {
            _employeeRepository.deleteEmployee(Id);
            return true;
        }

        public bool UpdateEmployee(Employee employee)
        {
            var data = _employeeRepository.Edit(employee);
            if (data != null)
            {
                data.Name = employee.Name;
                data.DOB = employee.DOB;
                data.Mobile = employee.Mobile;
            }
            _dbContext.SaveChanges();
            return true;
        }


    }
}
