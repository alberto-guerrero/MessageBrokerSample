using System;

namespace MessageBrokerSample.Messages
{
    public interface IOrderSubmitted
    {
        Guid OrderId { get; }
    }
}
