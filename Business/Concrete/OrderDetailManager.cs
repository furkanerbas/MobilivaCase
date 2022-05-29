using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void Add(OrderDetail orderDetail)
        {
            this._orderDetailRepository.Add(orderDetail);
        }

        public void Delete(OrderDetail orderDetail)
        {
            this._orderDetailRepository.Delete(orderDetail);
        }

        public IApiResponse<OrderDetail?> Get(Expression<Func<OrderDetail, bool>>? filter = null)
        {
            return new ApiResponse<OrderDetail?>("Sipariş detayı getirildi", "200", _orderDetailRepository.Get(filter));
        }

        public IApiResponse<List<OrderDetail?>> GetAll(Expression<Func<OrderDetail, bool>>? filter = null)
        {
            return new ApiResponse<List<OrderDetail?>>("Siparişler getirildi", "200", _orderDetailRepository.GetAll(filter));
        }

        public void Update(OrderDetail orderDetail)
        {
            this._orderDetailRepository.Update(orderDetail);
        }
    }
}
