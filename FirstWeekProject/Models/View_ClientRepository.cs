using System;
using System.Linq;
using System.Collections.Generic;
	
namespace FirstWeekProject.Models
{   
	public  class View_ClientRepository : EFRepository<View_Client>, IView_ClientRepository
	{

	}

	public  interface IView_ClientRepository : IRepository<View_Client>
	{

	}
}