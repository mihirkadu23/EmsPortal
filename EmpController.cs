using Microsoft.AspNetCore.Mvc;
using EmsPotral.Data;
using EmsPotral.Models;
namespace EmsPotral.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Emp());
        }
        public IActionResult About()
        {
            return View();
        }

        // LIST
        public IActionResult Index()
        {
            var employee = _context.Employee.ToList();
            return View(employee);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
       [HttpPost]
public IActionResult Create(Emp employee)
{
    if (ModelState.IsValid)
    {
        _context.Employee.Add(employee);
        _context.SaveChanges();

        ViewBag.Message = "Employee created successfully";

        return View(employee); // Pass model back to view
    }

    return View(employee);
}

        // GET
        public IActionResult Details()
        {
            return View();
        }

        // details
        [HttpPost]
        public IActionResult Details(int id)
        {
            var employee = _context.Employee.FirstOrDefault(s => s.EmpId == id);

            if (employee == null)
            {
                ViewBag.Message = "Employee not found";
                return View();
            }

            return View(employee);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var employee = _context.Employee.FirstOrDefault(s => s.EmpId == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Emp employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employee
                    .FirstOrDefault(s => s.EmpId == employee.EmpId);

                if (existingEmployee == null)
                {
                    ViewBag.Message = "Employee not found";
                    return View(employee);
                }

                existingEmployee.EmpName = employee.EmpName;
                existingEmployee.EmailID = employee.EmailID;
                existingEmployee.Age = employee.Age;
                existingEmployee.Phoneno = employee.Phoneno;
                existingEmployee.Role = employee.Role;

                _context.SaveChanges();

                ViewBag.Message = "Employee updated successfully";

                return View(existingEmployee);
            }

            return View(employee);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var employee = _context.Employee.Find(id);
            if (employee == null) return NotFound();

            _context.Employee.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

