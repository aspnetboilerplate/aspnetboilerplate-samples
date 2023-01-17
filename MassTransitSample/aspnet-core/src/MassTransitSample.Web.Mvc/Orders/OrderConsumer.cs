using System.Threading.Tasks;
using MassTransit;
using MassTransitSample.Orders.Dto;
using Microsoft.Extensions.Logging;

namespace MassTransitSample.Web.Orders
{
    public class OrderConsumer : IConsumer<OrderDto>
    {
        private readonly ILogger<OrderDto> _logger;

        public OrderConsumer(ILogger<OrderDto> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderDto> context)
        {
            _logger.LogInformation("Received order {code} with price {price}",
                context.Message.OrderName,
                context.Message.Price
            );

            await Task.CompletedTask;
        }
    }
}