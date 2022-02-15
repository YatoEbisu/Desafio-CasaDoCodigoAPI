using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public async Task<bool> ExistsInDatabaseAsync(Expression<Func<T, bool>> predicate)
        {
            return (await FindAsync(predicate)).Any();
        }
    }
}
