using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void Send(string name,string mail,string message)
        {
            List<User> users = new List<User>();
            users.Add(new User { Name = name, Mail = mail, Message = message });
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            using (var cfCon = connectionFactory.CreateConnection())
            using (var channel = cfCon.CreateModel())
            {
                channel.QueueDeclare
                (
                    queue: "bilgilendirme",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );
                var strJson = JsonConvert.SerializeObject(users);
                var body = Encoding.UTF8.GetBytes(strJson);

                channel.BasicPublish
                (
                    exchange: "",
                    routingKey: "bilgilendirme",
                    basicProperties: null,
                    body: body
                );
            }
        }
        public class User
        {
            public string Name { get; set; }
            public string Mail { get; set; }
            public string Message { get; set; }
        }
    }
}
