using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC5_Pracice1002.Models
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; set; }
        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Delete(T entity);
    }
}