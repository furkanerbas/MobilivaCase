using Business.Abstract;
using Entities.Dtos;
using Integrations.EmailService;
using Integrations.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private ILogger<HomeController> _logger;
        private IEmailSenderService _emailSenderService;

        public HomeController(IProductService productService,ILogger<HomeController> logger,
            IOrderService orderService, IEmailSenderService emailSenderService)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
            _emailSenderService = emailSenderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("get-products")]
        public IActionResult GetProducts(string? categoryName)
        {
            return categoryName == null ? Ok(_productService.GetAll()) :
                 Ok(_productService.GetAll(x => x.Category == categoryName));

        }
        [HttpPost("create-order")]
        public IActionResult CreateOrder(CreateOrderRequestDto orderRequest )
        {
            var res = _orderService.OnCreate(orderRequest);
            return Ok(res);
        }
    }
}
