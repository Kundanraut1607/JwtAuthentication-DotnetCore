using JWTAuthentication.Context;
using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;

namespace JWTAuthentication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtDBContext _dbContext;
        public EmployeeService(JwtDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
           var emp = _dbContext.Add(employee);
           _dbContext.SaveChanges();
            return emp.Entity;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (emp == null) 
            {
                throw new Exception("user not found");
            }
            else 
            {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
                return emp;
            }
        }

        public Employee GetEmployee(int id)
        {
            var emp = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (emp == null)
            {
                throw new Exception("user not found");
            }
            else
            {
                return emp;
            }

        }

        public List<Employee> GetEmployeeDetails()
        {
            return _dbContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }
    }
}
