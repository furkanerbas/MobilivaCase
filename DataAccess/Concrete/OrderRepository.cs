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
    public class OrderRepository : BaseRepository<Order,MobilivaDbContext>, IOrderRepository
    {
        public List<CreateOrderRequestDto> OrderRequest(Expression<Func<CreateOrderRequestDto, bool>> filter = null)
        {
            using (var context = new MobilivaDbContext())
            {
                var result = from o in context.Orders
                             join d in context.OrderDetails
                             on o.Id equals d.Id
                             join p in context.Products
                             on d.ProductId equals p.Id

                             select new CreateOrderRequestDto
                             {
                                 CustomerGSM = o.CustomerGSM,
                                 CustomerEmail = o.CustomerEmail,
                                 CustomerName = o.CustomerName,
                                 ProductId = d.ProductId,
                                 UnitPrice = p.UnitPrice,
                                 Amount = o.TotalAmount / p.UnitPrice 


                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }
    }
}
