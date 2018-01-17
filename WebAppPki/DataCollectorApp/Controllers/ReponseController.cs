using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCollectorApp.Controllers
{
    [Authorize]
    public class ReponseController : Controller
    {
        // GET: Reponse
        public ActionResult Index()
        {
            return View();
        }
    }
}