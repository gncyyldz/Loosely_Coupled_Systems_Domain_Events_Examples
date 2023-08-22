using Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatorDesignPattern;
using Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR;
using Loosely_Coupled_Systems_Domain_Events_Examples_API.Domain_Events.MediatR.Models.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loosely_Coupled_Systems_Domain_Events_Examples_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("create-order-delegate")]
        public IActionResult CreateOrderDelegate()
        {
            Domain_Events.Delegate.Order order = new();
            order.OrderCompleted += () =>
            {
                Console.WriteLine("Sipariş tamamlandığında buradaki kodlar tetiklenecektir!");
            };

            order.CompleteOrder();

            return Ok();
        }

        [HttpPost("create-order-eventhandlers")]
        public IActionResult CreateOrderEventHandlers()
        {
            Domain_Events.EventHandlers.Order order = new();
            order.OrderCompleted += (sender, e) =>
            {
                Console.WriteLine("Sipariş tamamlandığında buradaki kodlar tetiklenecektir!");
            };

            order.CompleteOrder();

            return Ok();
        }

        [HttpPost("create-order-mediator-design-pattern")]
        public IActionResult CreateOrderMediatorDesignPattern()
        {
            Domain_Events.MediatorDesignPattern.Order order = new();
            OrderMediator mediator = new();
            EmailService emailService = new();
            SmsService smsService = new();

            mediator.Register(emailService);
            mediator.Register(smsService);

            mediator.OrderCompleted(order);

            return Ok();
        }

        readonly IMediator _mediator;
        readonly ApplicationDbContext _applicationDbContext;
        public OrdersController(IMediator mediator, ApplicationDbContext applicationDbContext)
        {
            _mediator = mediator;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("create-order-mediatr")]
        public async Task<IActionResult> CreateOrderMediatR()
        {
            //OrderCreatedEvent orderCreatedEvent = new()
            //{
            //    OrderId = Guid.NewGuid(),
            //    OrderItems = new List<object> { "A", "B", "C" }
            //};
            //_mediator.Publish(orderCreatedEvent);
            Domain_Events.MediatR.Models.Order order = new()
            {
                Id = Guid.NewGuid(),
                OrderItems = new List<object>() { "A", "B", "C" }
            };
            order.Complete();
            await _applicationDbContext.Orders.AddAsync(order);
            await _applicationDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
