using DataClass.Models;
using Machin_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Machin_Test.Controllers
{
    public class EmployeeController : Controller
    {

        UnitTContext _db;

        public EmployeeController(UnitTContext db)
        {
            _db = db;
        }

       

        public IActionResult Index(string sreach)
        {
            List<Employee> E1= SerchEMP(sreach);
            return View(E1);
        }


        
        public List<Employee> SerchEMP(string Name)
        {
            List<Employee> models = null;
            if (!string.IsNullOrEmpty(Name))
            {
                 models=_db.Employees.Where(x => x.Name.Contains(Name)).Select(e=>
                 new Employee()
                 {
                     Name = e.Name,
                     Email = e.Email,
                     MobileNumber = e.MobileNumber,
                     Gender = e.Gender,
                     Address = e.Address,
                 }).ToList();
            }
            else
            {
               models=_db.Employees.OrderByDescending(x => x.Id).Select(e => new Employee()
               {
                   Name = e.Name,
                   Email = e.Email,
                   MobileNumber = e.MobileNumber,
                   Gender = e.Gender,
                   Address = e.Address,
               }).ToList();
            }


            return  models;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(EmployeeModel emp) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee()
                    {
                        // Id = emp.Id,
                        Name = emp.Name,
                        Email = emp.Email,
                        MobileNumber = emp.MobileNumber,
                        Gender = emp.Gender,
                        Address = emp.Address,
                    };
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("Name", "Error Accured");
            }

           return View();
        }
    }
}
