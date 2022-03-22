using CrudBootstrap.DB_Connect;
using CrudBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexDashBoard()
        {

            return View();
        }

        public ActionResult EmpTable()
        {
            crudEntities1 obj = new crudEntities1();

            List<EmpModel> empobj = new List<EmpModel>();

            var res = obj.employees.ToList();
            foreach (var item in res)
            {
                empobj.Add(new EmpModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Salary = item.Salary
                });
            }

            return View(empobj);
        }














        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}