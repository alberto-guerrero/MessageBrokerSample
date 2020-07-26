using MassTransit;
using System;
using System.Threading.Tasks;

namespace MessageBrokerSample.SendMessage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // RabbitMQ Host & Credentials
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();

            while (true)
            {
                Console.WriteLine("\nPress enter to send message. Type \"exit\" to quit. ");
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                var orderId = Guid.NewGuid();
                Console.WriteLine($"Submitting Order {orderId}");
                await bus.Publish(new OrderSubmitted(orderId));
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
