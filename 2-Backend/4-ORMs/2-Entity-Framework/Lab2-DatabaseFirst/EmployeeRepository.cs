using System.Collections.Generic;
using System.Linq;

namespace Lab2_DatabaseFirst
{
    public class EmployeeRepository
    {
        private readonly CompanyLiteDBEntities entities = new CompanyLiteDBEntities();

        public Employee GetById(int id) => entities.Employees.SingleOrDefault(x => x.Id == id);
        public IEnumerable<int> GetAllId() => entities.Employees.Select(emp => emp.Id);
        public IEnumerable<Employee> GetAll() => entities.Employees;
        public void Post(Employee emp) => entities.Employees.Add(emp);
        public void Put(Employee emp)
        {
            var employee = GetById(emp.Id);
            employee.Name = emp.Name;
            employee.DeptId = emp.DeptId;
        } 
        public void Delete(int id) => entities.Employees.Remove(GetById(id));
        public void Save() => entities.SaveChanges();
    }
}