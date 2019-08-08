using gezginler.Areas.admin.Models;
using gezginler.Data;
using gezginler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gezginler.Areas.admin.Controllers
{
    public class ResimController : Controller
    {
        MvcProjesiContext dbcontext = new MvcProjesiContext();
        // GET: admin/Resim
        public ActionResult Index()
        {
           // var dbcontext = new MvcProjesiContext();
            var model = dbcontext.Resims.OrderByDescending(x => x.ResimId).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        const string ImageFolderPath = "/Content/img/";

        public ActionResult ResimAdd(ResimModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (model.Resim != null && model.Resim.ContentLength > 0)
                {
                    fileName = model.Resim.FileName;
                    var path = Path.Combine(Server.MapPath("~"+ImageFolderPath), fileName);
                    model.Resim.SaveAs(path);
                }

                Resim resim = new Resim();
                resim.Resimyol =ImageFolderPath+ fileName;
                dbcontext.Resims.Add(resim);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Metinindex()
        {
            // var dbcontext = new MvcProjesiContext();
            var modl = dbcontext.Rehbers.OrderByDescending(x => x.RehberId).ToList();
            return View(modl);
        }

        public ActionResult Metinekle()
        {
            return View();
        }
        public ActionResult MetinAdd(Rehber modl)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Rehbers.Add(modl);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("Metinindex");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = dbcontext.Resims.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Resim model)
        {
            if (ModelState.IsValid)
            {
               
                dbcontext.Resims.Attach(model);
                dbcontext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}