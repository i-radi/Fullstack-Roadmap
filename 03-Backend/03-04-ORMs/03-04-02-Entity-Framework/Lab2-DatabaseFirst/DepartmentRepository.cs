using System.Collections.Generic;
using System.Linq;

namespace Lab2_DatabaseFirst
{
    public class DepartmentRepository
    {
        private readonly CompanyLiteDBEntities entities = new CompanyLiteDBEntities();

        public Department GetById(int id) => entities.Departments.SingleOrDefault(x => x.Id == id);
        public IEnumerable<int> GetAllId() => entities.Departments.Select(dep => dep.Id);
        public IEnumerable<Department> GetAll() => entities.Departments;
        public void Post(Department dept) => entities.Departments.Add(dept);
        public void Put(Department dept) => GetById(dept.Id).Name = dept.Name;
        public void Delete(int id) => entities.Departments.Remove(GetById(id));
        public void Save() => entities.SaveChanges();

    }
}