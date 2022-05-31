using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.RabbitMQ
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        public bool Get()
        {
            try
            {
                var cfBaglantiBilgileri = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };

                using (IConnection cfBaglanti = cfBaglantiBilgileri.CreateConnection())
                using (IModel chnKanal = cfBaglanti.CreateModel())
                {
                    chnKanal.QueueDeclare
                    (
                        queue: "bilgilendirme",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(chnKanal);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var jsonString = Encoding.UTF8.GetString(body);
                    };

                    chnKanal.BasicConsume
                    (
                        queue: "bilgilendirme",
                        autoAck: false, // true ise mesaj otomatik olarak kuyruktan silinir
                        consumer: consumer
                    );
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Kuyrukta bir hata oluştu"+ex.Message);
            }
            

            }
        }
    }
