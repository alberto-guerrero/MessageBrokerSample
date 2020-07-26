using MassTransit;
using MessageBrokerSample.Messages;
using System;
using System.Threading.Tasks;

namespace MessageBrokerSample.ReceiveMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // RabbitMQ Host & Credentials
                cfg.Host("localhost", "/", h =>
                 {
                     h.Username("guest");
                     h.Password("guest");
                 });

                // Add message consumers
                cfg.ReceiveEndpoint("order-events-listener", e =>
                 {
                     e.Consumer<MessageConsumer>();
                 });
            });

            bus.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }

        class MessageConsumer : IConsumer<IOrderSubmitted>
        {
            public Task Consume(ConsumeContext<IOrderSubmitted> context)
            {
                Console.WriteLine($"Order Submitted: {context.Message.OrderId}");
                return Task.CompletedTask;
            }
        }
    }
}
