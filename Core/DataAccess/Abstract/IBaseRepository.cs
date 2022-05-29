using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IBaseRepository
    {
        public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
        {
            List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
            TEntity Get(Expression<Func<TEntity, bool>> filter);
            bool Add(TEntity entity);
            bool Update(TEntity entity);
            bool Delete(TEntity entity);
        }
    }
}
