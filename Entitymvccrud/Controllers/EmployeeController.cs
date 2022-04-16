using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitymvccrud.Models;

namespace Entitymvccrud.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;

     public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {

            List<Employee> emps = dbContext.Employees.Where(z=>z.Status==true).ToList();

          


            return View(emps);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Employee emp)
        {
            emp.Status = true;
            emp.EmployeeDate = DateTime.Now;
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            ViewBag.Message = string.Format("Name", emp.Name);
            return RedirectToAction("Index");
        }



        public IActionResult Update(int id)

        {
            var tmp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (tmp != null)
            {
                var model = new Employee()
                {
                    Id = tmp.Id,
                    Name = tmp.Name,
                    Email = tmp.Email,
                    Gender=tmp.Gender,
                    Mobile_no = tmp.Mobile_no,
                    Address = tmp.Address,
                    
                };


                return View(tmp);
            }
            else
            {
                return RedirectToAction("index");
            }
        }


        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            Employee obj = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Gender=emp.Gender,
                Mobile_no = emp.Mobile_no,
                Address = emp.Address,
                Status = true,
                EmployeeDate = DateTime.Now
        };

            dbContext.Employees.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }



        public IActionResult Delete(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == id);
            //dbContext.Employees.Remove(emp);
            emp.Status = false;
            dbContext.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
