using gezginler.Data;
using gezginler.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace gezginler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Resim()
        {
            MvcProjesiContext db = new MvcProjesiContext();
            var liste = db.Resims.OrderByDescending(x => x.ResimId) ;
           
            return View(liste);
        }



        [ChildActionOnly]
        public ActionResult _Rehber()
        {
            MvcProjesiContext db = new MvcProjesiContext();
            var liste = db.Rehbers.OrderByDescending(x => x.RehberId);

            return View(liste);
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


        public ActionResult Uyeol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Uyeol(Uye model)
        
        {
            if (ModelState.IsValid)
            {
                var uye = new Uye() { Ad = model.Ad, Soyad = model.Soyad, EPosta = model.EPosta, Parola = model.Parola };
                var dbcontext = new MvcProjesiContext();
                dbcontext.Uyes.Add(uye);
                dbcontext.SaveChanges();
                return View("Kayitbasarili", model);
                
            }
            else
            {
                return View();
            }
            
            }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uye model)
        {
            //Request.Form["html elementinin name özelliği"] ile Post edilen formdaki elemanların
            //değerlerini alabiliyoruz. Bu metod yalnızca Post ile çalışır.
            var posta = model.EPosta;
            var sifre = model.Parola;
            
            if (String.IsNullOrEmpty(posta) && String.IsNullOrEmpty(sifre))
            {
                ViewBag.Message =" E - Posta adresinizi ve şifrenizi girmediniz.";
                return View();

            }
            else if (String.IsNullOrEmpty(posta))
            {
                ViewBag.Message = " E - Posta adresinizi girmediniz.";
                return View();
            }
            else if (string.IsNullOrEmpty(sifre))
            {
                ViewBag.Message = " şifrenizi girmediniz.";
                return View();
            }
            else
            {
                using (MvcProjesiContext db = new MvcProjesiContext())
                {
                    //Normalde şifreyi hashleyerek yazdırmamız ve kontrol etmemiz gerekir.
                    var uye = (from i in db.Uyes where i.Parola == sifre && i.EPosta == posta select i).SingleOrDefault();

                    if (uye == null) ViewBag.Message = "Kullanıcı adınızı ya da şifreyi hatalı girdiniz.";

                    //Session'da müşteri ile ilgili bilgileri saklamaktayız.
                    //Güvenlik açısından bilgileri şifreleyerek saklamamız daha doğru bir yöntemdir.
                    //Asp.Net Membership yapısı, bu güvenliği sunmaktadır.
                    Session["uyeId"] = uye.UyeId;

                    //Burada eğer, kullanıcı bilgileri, sistemde eşleşirse, geriye girişin başarılı
                    //olduğuna dair bir mesaj ve 3 saniye sonra, ana sayfaya yönlendirecek bir
                    //javascript kodu ekliyoruz.
                    //return RedirectToAction("Add","Resim");
                    //return "Sisteme, başarıyla giriş yaptınız.<script type='text/javascript'>setTimeout(function(){window.location='../admin/Resim/Index'},3000);</script>";
                   
                }
                return RedirectToAction("Index", "admin/Adminhome");
            }
            
               
            
        }

        public ActionResult Kayitbasarili()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
       
    }
