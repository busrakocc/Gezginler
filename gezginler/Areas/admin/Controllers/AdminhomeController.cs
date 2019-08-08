using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gezginler.Areas.admin.Controllers
{
    public class AdminhomeController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anasayfayadon()
        {
            return RedirectToAction("Index", "../Home");
        }

        public ActionResult Cikisyap()
        {
            return RedirectToAction("cikis", "../Home");
        }
    }
}