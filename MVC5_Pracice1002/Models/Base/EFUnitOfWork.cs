using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext context { get; set; }

        public EFUnitOfWork()
        {
            context = new FabricsEntities();
        }

        public void Commit()
        {
            context.SaveChanges();
        }


        public bool LazyLoadingEnabled
        {
            get { return context.Configuration.LazyLoadingEnabled; }
            set { context.Configuration.LazyLoadingEnabled = value; }
        }

        public bool ProxyCreationEnabled
        {
            get { return context.Configuration.ProxyCreationEnabled; }
            set { context.Configuration.ProxyCreationEnabled = value; }
        }


        public string ConnectionString
        {
            get { return context.Database.Connection.ConnectionString; }
            set { context.Database.Connection.ConnectionString = value; }
        }
        
    }
}