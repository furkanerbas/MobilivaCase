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
    public class OrderDetailRepository : BaseRepository<OrderDetail,MobilivaDbContext>, IOrderDetailRepository
    {
        public List<OrderDetailDto> GetProductDetail(Expression<Func<OrderDetailDto, bool>> filter = null)
        {
            using (MobilivaDbContext context = new MobilivaDbContext())
            {
                var result = from p in context.Products
                             join od in context.OrderDetails on p.Id equals od.ProductId
                             join or in context.Orders on od.OrderId equals or.Id

                             select new OrderDetailDto
                             {
                                 Id = od.Id,
                                 CustomerName = or.CustomerName,
                                 Description = p.Description,
                                 UnitPrice = p.UnitPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
