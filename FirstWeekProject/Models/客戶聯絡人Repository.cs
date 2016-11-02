using System;
using System.Linq;
using System.Collections.Generic;
	
namespace FirstWeekProject.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        客戶資料Entities db = new 客戶資料Entities();
        public 客戶資料Entities Get客戶資料()
        {
            return db;
        }
        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(w => w.Id == id);
        }
        public void Delete(int Id)
        {
            this.Find(Id).IsDelete = true;
            //this.UnitOfWork.Commit();         
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}