using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DataCollectorApp.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authenticate(string user_login, string user_password, string  returnUrl)
        {
            // stuff to create session data
            Session[DataCollectorApp.Models.mHelpers.login_key] = user_login;

            FormsAuthentication.SetAuthCookie(user_login, false);

            if(!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
                                      
            return RedirectToAction("Index", "Indicateur");
        }


        public ActionResult Exit()
        {
            // stuff to destroy session data
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
            //return View();

        }
    }
}