﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.BLL.Models.Departments
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage = "Code is Required" )]
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Display(Name = "Date Of Creation")]

        public DateOnly CreationDate { get; set; }
    }
}