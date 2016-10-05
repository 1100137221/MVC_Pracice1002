using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_Pracice1002.Models
{
    public interface IUnitOfWork
    {
        DbContext context { get; set; }
 		void Commit();
 		bool LazyLoadingEnabled { get; set; }
 		bool ProxyCreationEnabled { get; set; }
 		string ConnectionString { get; set; }
    }
}
