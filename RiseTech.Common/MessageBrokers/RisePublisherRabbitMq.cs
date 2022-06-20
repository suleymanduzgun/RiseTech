using RabbitMQ.Client;

namespace RiseTech.Common.MessageBrokers
{
	public class RisePublisherRabbitMq
	{
		private readonly ConnectionFactory _factory;

		public RisePublisherRabbitMq(ConnectionFactory factory)
		{
			_factory = factory;
			_factory.Uri = new Uri("amqp://localhost:5672");
		}



		public void FanoutExchange(string routeKey, byte[] messageBody)
		{
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.ExchangeDeclare("Rise-Fanout", durable: true, type: ExchangeType.Fanout);
			channel.BasicPublish("Rise-Fanout", routeKey, null, messageBody);
		}


		public void DirectExchange(string routeKey, byte[] messageBody)
		{
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.ExchangeDeclare("Rise-Direct", durable: true, type: ExchangeType.Direct);

			var queueName = "rise-direct-queue";
			channel.QueueDeclare(queueName, true, false, false);
			channel.QueueBind(queueName, "Rise-Direct", routeKey);

			channel.BasicPublish("Rise-Direct", routeKey, null, messageBody);
		}


		public void TopicExchange(string routeKey, byte[] messageBody)
		{
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.ExchangeDeclare("Rise-Topic", durable: true, type: ExchangeType.Topic);
			channel.BasicPublish("Rise-Topic", routeKey, null, messageBody);
		}


		public void THeaderExchange(string routeKey, byte[] messageBody)
		{
			using var connection = _factory.CreateConnection();
			var channel = connection.CreateModel();
			channel.ExchangeDeclare("Rise-Headers", durable: true, type: ExchangeType.Headers);
			// devamını yazacağım....
			channel.BasicPublish("Rise-Headers", routeKey, null, messageBody);
		}



	}
}
