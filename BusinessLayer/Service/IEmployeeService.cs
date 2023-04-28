namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        public Employee GetPersonByUserId(int Id);
        public List<Employee> GetEmployees();
        public Task<Employee> AddEmployee(Employee employee);
        public bool deleteEmployee(int Id);
        public bool UpdateEmployee(Employee employee);


    }
}
