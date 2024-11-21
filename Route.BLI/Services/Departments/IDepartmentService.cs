using Route.BLL.Models.Departments;
using Route.DAL.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.BLL.Services.Departments
{
    public interface IDepartmentService
    {

        IEnumerable<DepartmentToReturnDto> GetAllDepartments(); 

        DepartmentDetailsToReturnDto? GetDepartmentById(int id);


        int CreateDepartment(CreatedDepartmentDto department);

        int UpdateDepratment(UpdatedDepartmentDto department);

        bool DeleteDepartment(int id);

    }
}
