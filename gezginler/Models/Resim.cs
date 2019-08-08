using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gezginler.Models
{
    public class Resim
    {
        public int ResimId { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Lütfen resim yolunuzu doğru şekilde giriniz.")]
        public string Resimyol { get; set; }

        public virtual Uye Uye { get; set; }
    }
}