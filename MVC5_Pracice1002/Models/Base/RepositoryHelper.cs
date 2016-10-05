using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public static class RepositoryHelper
    {
        public static IUnitOfWork GetUnitOfWork()
        {
            return new EFUnitOfWork();
        }

        public static ProductRepository ProductRepository()
        {
            var repo = new ProductRepository();
            repo.UnitOfWork = GetUnitOfWork();
            return repo;
        }
    }
}