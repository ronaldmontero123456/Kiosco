using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        Task<T> GetById(int id);
        Task<T> GetById(Expression<Func<T, bool>> where);
        Task Add(T entity);
        Task AddRange(List<T> entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
