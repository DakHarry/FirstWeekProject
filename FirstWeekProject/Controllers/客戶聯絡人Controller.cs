using FirstWeekProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace FirstWeekProject.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶聯絡人
        public ActionResult Index(string keyword)
        {
            var data = db.客戶聯絡人.Include(w => w.客戶資料 ).ToList();
            if (!String.IsNullOrEmpty(keyword))
            {
                data = db.客戶聯絡人.Where(w => w.姓名.Contains(keyword)).ToList();
            }
            //關聯下拉是選單
                   
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 data)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", data.客戶Id);
            return View(data);
           // return RedirectToAction("Create");
           // List<SelectListItem> items = new List<SelectListItem>();
            //if(data.客戶Id != null)
            //{
            //    items.Add(new SelectListItem()
            //    {
            //        Text = data.客戶Id.ToString(),
            //        Value = data.客戶Id.ToString()
            //    });
            //}



         //   return View(data);
        }
        //id 不一定有值，須設定int?
        public ActionResult Edit(int? id)
        {

          //  var data = db.客戶聯絡人.Where(w => w.客戶Id == id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //抓一筆可以用Find
            客戶聯絡人 data = db.客戶聯絡人.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", data.客戶Id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 data) { 
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", data.客戶Id);
            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            客戶聯絡人 data= db.客戶聯絡人.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                db.SaveChanges();
             return    RedirectToAction("Index");
            }
            //db.客戶聯絡人.Remove(data);
            //db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 data = db.客戶聯絡人.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
    }
}