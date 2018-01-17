
using DataCollectorApp.Models;
using DataCollectorApp.Models.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCollectorApp.Controllers
{
    [Authorize]
    public class EnqueteController : Controller
    {
        
        // GET: Enquete
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Liste()
        {
            using (var ctx =  new DataCollectorContext())
            {
                var liste = ctx.Enquete.ToList();

                return View(liste);
            }            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DataCollectorApp.Models.Enquete mClass)
        {
            //if (ModelState.IsValid)
            //{
                using (var ctx = new DataCollectorContext())
                {
                    mClass.enCibleEnqueteID = 1;    
                    
                    ctx.Enquete.Add(mClass);

                    ctx.SaveChanges();
                } 
            //}
            
            return RedirectToAction("Liste");


        }


        public ActionResult Creer()
        {
            return new Ext.Net.MVC.PartialViewResult { ViewName = "Enquete_Detail" };            
        }


        public ActionResult Enquete_Creer()
        {
            return View();
        }


        public ActionResult Modifier()
        {
            return View();
        }
    }
}