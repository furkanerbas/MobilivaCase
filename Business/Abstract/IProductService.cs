using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public IApiResponse<List<Product?>> GetAll(Expression<Func<Product,bool>>? filter = null);
        public IApiResponse<Product?> Get(Expression<Func<Product,bool>>? filter = null);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Product product);
    }
}
