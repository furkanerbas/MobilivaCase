using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Integrations.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        private IRabbitMQProducer _rabbitMQProducer;
        private RabbitMQConsumer _rabbitMQConsumer;
        public OrderManager(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository,
            IRabbitMQProducer rabbitMQProducer, RabbitMQConsumer rabbitMQConsumer)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _rabbitMQProducer = rabbitMQProducer;
            _rabbitMQConsumer = rabbitMQConsumer;
        }
        public void Add(Order order)
        {
            this._orderRepository.Add(order);
        }

        public void Delete(Order order)
        {
            this._orderRepository.Delete(order);
        }

        public IApiResponse<Order?> Get(Expression<Func<Order, bool>>? filter = null)
        {
            return new ApiResponse<Order?>("Sipariş getirildi", "200", _orderRepository.Get(filter));
        }

        public IApiResponse<List<Order?>> GetAll(Expression<Func<Order, bool>>? filter = null)
        {
            return new ApiResponse<List<Order?>>("Siparişler getirildi", "200", _orderRepository.GetAll(filter));

        }
        public void Update(Order order)
        {
            this._orderRepository.Update(order);
        }
        public int OnCreate(CreateOrderRequestDto orderRequest = null)
        {
            Order order = new Order();
            var name = orderRequest.CustomerName;
            var mail = orderRequest.CustomerEmail;
            var customerGSM = orderRequest.CustomerGSM;

            order.CustomerName = name;
            order.CustomerEmail = mail;
            order.CustomerGSM = customerGSM;

            _orderRepository.Add(order);

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderId = order.Id;
            foreach (var product in orderRequest.ProductDetails)
            {
                var getProduct = _productRepository.Get(x => x.Id == product.ProductId);
                orderDetail.ProductId = getProduct.Id;
                orderDetail.UnitPrice = getProduct.UnitPrice;
            }
            _orderDetailRepository.Add(orderDetail);
            _rabbitMQProducer.Send(name, mail, "Sipariş oluşturuldu");
            return order.Id;
        }
    }
}
