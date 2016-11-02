using System;
using System.Linq;
using System.Collections.Generic;
	
namespace FirstWeekProject.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public void Delete(int Id)
        {
            this.Find(Id).IsDelete = true;
            //this.UnitOfWork.Commit();         
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}