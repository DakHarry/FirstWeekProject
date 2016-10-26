using FirstWeekProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeekProject.Controllers
{
    public class View_ClientController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        // GET: View_Client
        public ActionResult Index(string keyword)
        {

            var data = db.View_Client.ToList();

            if (!String.IsNullOrEmpty(keyword))
            {
                data = db.View_Client.Where(w => w.客戶名稱.Contains(keyword)).ToList();
            }
            return View(data);
        }
    }
}