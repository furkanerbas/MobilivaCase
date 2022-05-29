using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductRepository : BaseRepository<Product, MobilivaDbContext>, IProductRepository
    {
        public List<ProductDto> GetProductDetail(Expression<Func<ProductDto, bool>> filter = null)
        {
            using (MobilivaDbContext context = new MobilivaDbContext())
            {
                var result = from p in context.Products

                             select new ProductDto
                             {
                                 Id = p.Id,
                                 Description = p.Description,
                                 Category = p.Category,
                                 Unit = p.Unit,
                                 UnitPrice = p.UnitPrice,
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
