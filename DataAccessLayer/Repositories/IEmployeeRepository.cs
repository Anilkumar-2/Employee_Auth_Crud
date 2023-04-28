namespace DataAccessLayer.Repositories
{
    using DataAccessLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeRepository
    {
        public Employee GetById(int Id);
        public IQueryable<Employee> GetAllEmployee();
        public Task<Employee> AddEmployee(Employee employee);
        public void deleteEmployee(int Id);
       // public void UpdateEmployee(Employee employee);
        public Employee Edit(Employee employee);

    }
}
