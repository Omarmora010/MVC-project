using Route.DAL.Entities.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Route.BLL.Models.Departments
{
    public class DepartmentToReturnDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        [Display(Name = "Date Of Creation")]

        public DateOnly CreationDate { get; set; }
    }
}
