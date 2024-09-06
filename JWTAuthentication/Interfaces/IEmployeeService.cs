using JWTAuthentication.Models;

namespace JWTAuthentication.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeDetails();
        public Employee GetEmployee(int id);
        public Employee AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);
    }
}
