using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public static class RepositoryHelper
    {
        public static ProductRepository ProductRepository()
        {
            var repo = new ProductRepository();
            return repo;
        }
    }
}