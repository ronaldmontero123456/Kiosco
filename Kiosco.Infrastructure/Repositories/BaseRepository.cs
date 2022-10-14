using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace Kiosco.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> dbSet;
        protected readonly KioscoContext _context;

        public BaseRepository(KioscoContext Context)
        {
            _context = Context;
            dbSet = Context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task AddRange(List<T> entity)
        {
            try
            {
                await dbSet.AddRangeAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            dbSet.Remove(entity);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<T> GetById(Expression<Func<T, bool>> where)
        {
            return await dbSet.FirstOrDefaultAsync(where);
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
