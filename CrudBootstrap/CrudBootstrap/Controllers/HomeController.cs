using CrudBootstrap.DB_Connect;
using CrudBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CrudBootstrap.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInfoModel userobj)
        {
            crudEntities1 obj = new crudEntities1();
            var UserRes = obj.user_info.Where(a => a.email == userobj.email).FirstOrDefault();

            if (UserRes == null)
            {
                TempData["Invalid"] = "Email not found or Invalid Username";
            }
            else
            {
                if(UserRes.email==userobj.email && UserRes.password == userobj.password)
                {
                    FormsAuthentication.SetAuthCookie(UserRes.email, false);

                    Session["username"] = UserRes.name;
                    Session["useremail"] = UserRes.email;
                    return RedirectToAction("IndexDashboard", "Home");
                }
                else
                {
                    TempData["Wrong"] = "Wrong Email or Password";
                    return View();
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult IndexDashBoard()
        {

            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
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













        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}