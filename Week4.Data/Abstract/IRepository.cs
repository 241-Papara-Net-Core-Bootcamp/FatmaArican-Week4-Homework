using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Data.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> Delete(int id);
        Task<int> Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
    }
}
