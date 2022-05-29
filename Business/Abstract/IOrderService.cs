using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public IApiResponse<List<Order?>> GetAll(Expression<Func<Order, bool>>? filter = null);
        public IApiResponse<Order?> Get(Expression<Func<Order, bool>>? filter = null);
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(Order order);
        public int OnCreate(CreateOrderRequestDto orderRequest = null);
    }
}
