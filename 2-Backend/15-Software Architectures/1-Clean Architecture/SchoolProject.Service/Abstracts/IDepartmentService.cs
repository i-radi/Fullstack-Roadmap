﻿using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<bool> IsDepartmentIdExist(int departmentId);
    }
}
