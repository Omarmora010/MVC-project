using Microsoft.AspNetCore.Mvc;
using Route.BLL.Models.Departments;
using Route.BLL.Services.Departments;

namespace Route.PL.Controllers
{ 
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService , ILogger<DepartmentController> logger , IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
            _departmentService = departmentService;
        }

        [HttpGet] // Get : /Department/Index

        public IActionResult Index()
        {

            var departments = _departmentService.GetAllDepartments();



            return View(departments);

        }


        [HttpGet] // Get : /Department/Create

        public IActionResult Create()
        { 
        return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);

            }
            var message = string.Empty;
            try
            {
                var result = _departmentService.CreateDepartment(department);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "Department Is Not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(department);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex , ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(department);

                }
                else
                {
                    message = "Department Is Not Craeted";
                    return View("Error", message);
                }


            }
        }

        [HttpGet] // Get : /Department/Details
        public IActionResult Details(int? id) 
        { 
           if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();

            return View(department);
        }
    }
}
