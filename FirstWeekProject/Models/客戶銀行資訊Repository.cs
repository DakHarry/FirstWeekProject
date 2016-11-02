using System;
using System.Linq;
using System.Collections.Generic;
	
namespace FirstWeekProject.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public 客戶銀行資訊 Find(int Id)
        {
            return this.All().FirstOrDefault(w => w.Id == Id);
        }
        public void Delete(int Id)
        {
            this.Find(Id).IsDelete = true;
           //this.UnitOfWork.Commit();         
        }
	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}