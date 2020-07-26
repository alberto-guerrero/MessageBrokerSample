# MessageBrokerSample

Simple RabbitMQ / Masstransit example.
This example use the following docker command to run RabbitMQ:

```docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management```

Once the container is running. You can log into the management console: http://localhost:15672/

Username: guest
Password: guest
