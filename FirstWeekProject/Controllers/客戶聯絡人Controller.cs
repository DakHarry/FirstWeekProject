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
       // private 客戶資料Entities db = new 客戶資料Entities();
        private 客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        // GET: 客戶聯絡人
        public ActionResult Index(string keyword,string ClientData)
        {
            //var data = repo.Include(w => w.客戶資料 ).ToList();
            var data = repo.All().Include(w =>w.客戶資料).ToList();
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(w => w.姓名.Contains(keyword)).ToList();
            }

            return View(data);
        }

        public ActionResult Create()
        {
            
            ViewBag.客戶Id = new SelectList(repo.Get客戶資料().客戶資料, "Id", "客戶名稱");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 data)
        {
            if (ModelState.IsValid)
            {
                repo.Add(data);
                
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");

            }
            ViewBag.客戶Id = new SelectList(repo.Get客戶資料().客戶資料, "Id", "客戶名稱", data.客戶Id);
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

          //  var data = repo.Where(w => w.客戶Id == id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //抓一筆可以用Find
            客戶聯絡人 data = repo.Find(id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo.Get客戶資料().客戶資料, "Id", "客戶名稱", data.客戶Id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 data) { 
            if (ModelState.IsValid)
            {
                repo.UnitOfWork.Context.Entry(data).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo.Get客戶資料().客戶資料, "Id", "客戶名稱", data.客戶Id);
            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            客戶聯絡人 data= repo.Find(id.Value);
            if (data != null)
            {
                // data.IsDelete = true;
                repo.Delete(id.Value);
                repo.UnitOfWork.Commit();
             return RedirectToAction("Index");
            }
            //repo.Remove(data);
            //repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 data = repo.Find(id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
    }
}