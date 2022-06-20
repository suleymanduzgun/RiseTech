using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RiseTech.Common.MessageBrokers
{
	public class RiseConsumerRabbitMq
	{
		private readonly ConnectionFactory _factory;

		public RiseConsumerRabbitMq(ConnectionFactory factory)
		{
			_factory = factory;
			_factory.Uri = new Uri("amqp://localhost:5672");
		}


		public byte[] RiseFanoutConsumer()
		{
			var result = new byte[int.MaxValue];
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			var randomQueueName = channel.QueueDeclare().QueueName;
			channel.QueueBind(randomQueueName, "Rise-Fanout", "", null);
			channel.BasicQos(0, 1, false);
			var consumer = new EventingBasicConsumer(channel);
			channel.BasicConsume(randomQueueName, false, consumer);

			consumer.Received += (object? sender, BasicDeliverEventArgs e) =>
			{
				channel.BasicAck(e.DeliveryTag, false);
				result = e.Body.ToArray();
			};
			return result;
		}


		public byte[] RiseDirectConsumer()
		{
			var result = new byte[int.MaxValue];
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.BasicQos(0, 1, false);
			var consumer = new EventingBasicConsumer(channel);
			var queueName = channel.QueueDeclare().QueueName;
			channel.BasicConsume(queueName, false, consumer);
			consumer.Received += (object? sender, BasicDeliverEventArgs e) =>
			{
				channel.BasicAck(e.DeliveryTag, false);
				result = e.Body.ToArray();
			};
			return result;
		}


		public byte[] RiseTopicConsumer(string routeKey)
		{
			var result = new byte[int.MaxValue];
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.BasicQos(0, 1, false);
			var consumer = new EventingBasicConsumer(channel);
			var queueName = channel.QueueDeclare().QueueName;
			channel.QueueBind(queueName, "Rise-Topic", routeKey);
			channel.BasicConsume(queueName, false, consumer);

			consumer.Received += (object? sender, BasicDeliverEventArgs e) =>
			{
				channel.BasicAck(e.DeliveryTag, false);
				result = e.Body.ToArray();
			};
			return result;
		}

		//Todo: Rise Header...


	}
}
