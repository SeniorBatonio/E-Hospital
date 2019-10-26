using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Hospital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var c = new E_Hospital.EF.Repositories.DoctorRepository();
            var d = c.GetDoctorDetails(1);
            return View(d);
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