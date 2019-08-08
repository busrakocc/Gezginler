using gezginler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gezginler.Data
{
    public class MvcProjesiContext : DbContext
    {
        public MvcProjesiContext() : base("MvcProjesiContext") { }
       
            //Daha sonra veritabanımızda, tablo olarak temsil edilecek tüm sınıflarımızı DbSet<..> içerisinde tek tek
            //çağırıyoruz. Sonuna s takısı koyduğumuza dikkat edin. Böylelikle bunun tablo olduğunu anlıyor olacağız.
            //Önceki yazımızda bahsettiğimiz gibi, sonunda zaten s olan bir sınıf ismimiz varsa, bu sefer de s takısını
            //kaldırabiliriz.
          
            public DbSet<Rehber> Rehbers { get; set; }
            public DbSet<Uye> Uyes { get; set; }
            public DbSet<Resim> Resims { get; set; }



    }

}