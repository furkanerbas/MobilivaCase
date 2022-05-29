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
    public interface IOrderDetailService
    {
        public IApiResponse<List<OrderDetail?>> GetAll(Expression<Func<OrderDetail, bool>>? filter = null);
        public IApiResponse<OrderDetail?> Get(Expression<Func<OrderDetail, bool>>? filter = null);
        public void Add(OrderDetail orderDetail);
        public void Update(OrderDetail orderDetail);
        public void Delete(OrderDetail orderDetail);
    }
}
