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
            if (categoryName == null)
            {
                _logger.LogInformation("Tüm ürünler getirildi");
                return Ok(_productService.GetAll());
            }
            _logger.LogInformation(categoryName, " türündeki ürünler getirildi");
            return Ok(_productService.GetAll(x => x.Category == categoryName));
        }
        [HttpPost("create-order")]
        public IActionResult CreateOrder(CreateOrderRequestDto orderRequest )
        {
            var res = _orderService.OnCreate(orderRequest);
            return Ok(res);
        }

        [HttpGet("send-mail")]
        public IActionResult MailQue(EmailMessageModel model)
        {
            _emailSenderService.SendAsync(model);
            return Ok();
            //RabbitMQProducer rabbitMQProducer = new RabbitMQProducer();
            //rabbitMQProducer.Send("furkan","furkanerbass@hotmail.com","mesaj");
            //RabbitMQConsumer rabbitMQConsumer = new RabbitMQConsumer();
            //rabbitMQConsumer.Get();
            //return Ok();
        }

    }
}
