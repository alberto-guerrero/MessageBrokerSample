using MessageBrokerSample.Messages;
using System;

namespace MessageBrokerSample.SendMessage
{
    public class OrderSubmitted : IOrderSubmitted
    {
        public OrderSubmitted(Guid orderId) => OrderId = orderId;

        public Guid OrderId { get; private set; }
    }
}
