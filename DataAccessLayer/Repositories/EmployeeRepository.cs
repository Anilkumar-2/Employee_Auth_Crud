namespace DataAccessLayer.Repositories
{
    using DataAccessLayer.DATA;
    using DataAccessLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmployeeRepository: IEmployeeRepository
    {
        ApplicationDbContext _dbContext;
        public EmployeeRepository (ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public Employee GetById(int Id)
        {
            return _dbContext.Employees.Where(x =>x.Id == Id).FirstOrDefault();
        }
        public IQueryable<Employee> GetAllEmployee()
        {
            return _dbContext.Employees;
        }
        public async Task<Employee> AddEmployee(Employee _employee)
        {
            var obj = await _dbContext.Employees.AddAsync(_employee);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public void deleteEmployee(int Id)
        {
            var data= _dbContext.Employees.Where(x=>x.Id==Id);
            _dbContext.RemoveRange(data);
            _dbContext.SaveChanges();
        }
        //public void UpdateEmployee(Employee employee)
        //{

        //    _dbContext.Employees.
        //    _dbContext.SaveChanges();

        //}

        public Employee Edit(Employee employee)
        {
            var abc = _dbContext.Employees.Find(employee.Id);
            return abc;
        }
    }
}
