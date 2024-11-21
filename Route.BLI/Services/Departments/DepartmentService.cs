using Microsoft.EntityFrameworkCore;
using Route.BLL.Models.Departments;
using Route.DAL.Entities.Departments;
using Route.DAL.Persistance.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepositry _departmentRepositry;

        public DepartmentService(IDepartmentRepositry departmentRepositry)
        {
            _departmentRepositry = departmentRepositry;
        }

        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            var departments = _departmentRepositry.GetAllAsIQueryable().Select(department => new DepartmentToReturnDto
            {

                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate

            }).AsNoTracking().ToList();

            return departments;
        }

        public DepartmentDetailsToReturnDto? GetDepartmentById(int id)
        {
            var department = _departmentRepositry.GetById(id);
            if (department != null)
                return new DepartmentDetailsToReturnDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,

                };
            return null;
        }

        public int CreateDepartment(CreatedDepartmentDto department)
        {

            var createdDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = 1
            };

            return _departmentRepositry.Add(createdDepartment);

        }

        public int UpdateDepratment(UpdatedDepartmentDto department)
        {
            var updatedDepartment = new Department()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = 1
            };


            return _departmentRepositry.Update(updatedDepartment);
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepositry.GetById(id);
            if (department is { })
                return _departmentRepositry.Delete(department) > 0;
            return false;


        }
    }
}
