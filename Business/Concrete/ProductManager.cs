using Business.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Integrations.RabbitMQ;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IMemoryCache _memoryCache;
        private ICacheManager _cacheManager;
        private ILogger<ProductManager> _logger;


        public ProductManager(IProductRepository productRepository, ICacheManager cacheManager,
            IMemoryCache memoryCache, IOrderRepository orderRepository, ILogger<ProductManager> logger,
            IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _cacheManager = cacheManager;
            _memoryCache = memoryCache;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _logger = logger;
        }
        public void Add(Product product)
        {
            this._productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            this._productRepository.Delete(product);
        }

        public IApiResponse<Product?> Get(Expression<Func<Product, bool>>? filter = null)
        {
            return new ApiResponse<Product?>("Ürün getirildi", "200", _productRepository.Get(filter));
        }

        public IApiResponse<List<Product?>> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            const string key = "personeller";
            List<Product> products = _productRepository.GetAll(filter).ToList();
            if (_memoryCache.TryGetValue(key, out object list))
            {
                products = (List<Product>)list;
                _logger.LogInformation("Ürünler cacheden getirildi");
                return new ApiResponse<List<Product?>>("Ürünler getirildi", "200", products.ToList());

            }
            products = _productRepository.GetAll(filter);
            _cacheManager.Set(key, products, 50);
            _logger.LogInformation("Ürünler  getirildi");
            return new ApiResponse<List<Product?>>("Ürünler getirildi", "200", products.ToList());
        }
        public void Update(Product product)
        {
            this._productRepository.Update(product);
        }

        
    }
}
