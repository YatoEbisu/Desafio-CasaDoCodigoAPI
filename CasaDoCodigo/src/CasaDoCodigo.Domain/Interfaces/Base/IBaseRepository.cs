using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Insert(T obj);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsInDatabaseAsync(Expression<Func<T, bool>> predicate);
    }
}
