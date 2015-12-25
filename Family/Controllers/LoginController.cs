using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Family.Models;
namespace Family.Controllers
{
    public class LoginController : Controller
    {
        FamilyModel fm = new FamilyModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="E_Mail,Password")] LoginViewModel Login)
        {
            var User = (from U in fm.Users
                       where U.E_Mail == Login.E_Mail && U.Password == Login.Password
                       select U).ToList();
            

            if (User.Count > 0)
            {
                Session["ID"] = User[0].User_Id;
                return Redirect("~/Users");
            }
            ViewBag.Error = "Invalid Login";
            return View();
            
        }
    }
}