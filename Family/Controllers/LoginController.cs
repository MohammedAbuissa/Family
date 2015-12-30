using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Family.Models;
using System.Web.Helpers;
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
            List<User> User;
            try
            {
                User = (from U in fm.Users
                            where U.E_Mail == Login.E_Mail
                            select U).ToList();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        //raise a new exception inserting the current one as the InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            if (User.Count > 0 && Crypto.VerifyHashedPassword(User[0].Password, Login.Password))
            {
                Session["ID"] = User[0].User_Id;
                return Redirect("~/Users");
            }
            ViewBag.Error = "Invalid Login";
            return View();
            
        }
    }
}