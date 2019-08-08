using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gezginler.Areas.admin.Models
{
    public class ResimModel
    {
        public int ID { get; set; }
        public HttpPostedFileBase Resim { get; set; }
    }
}