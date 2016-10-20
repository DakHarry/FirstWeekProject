using FirstWeekProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeekProject.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        // GET: 客戶聯絡人
        public ActionResult Index()
        {          
            return View(db.客戶聯絡人.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}