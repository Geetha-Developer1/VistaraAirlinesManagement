using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaraAirlinesManagement.Models;

namespace VistaraAirlinesManagement.Controllers
{
    public class UserController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            if (ModelState.IsValid)
            {

                if (m.role == "Employee")
                {
                    var eemp = context.EmployeeLogin.FirstOrDefault(x => x.Username == m.Username&&x.Password==m.Password );
                    if (eemp != null)
                    {
                        return RedirectToAction("EmployeeHome", "Employ");
                    }
                }
                else if (m.role == "Administrator")
                {
                    var eadmin = context.ManagerLogin.FirstOrDefault(x => x.Username ==m. Username && x.Password ==m. Password);
                    if (eadmin != null)
                    {
                        return RedirectToAction("AdminHome", "Admin");
                    }
                }
                else
                {
                    ViewBag.Message = "Incorrect Username or Password";
                }

            }
            return View();
        }
    }
}
