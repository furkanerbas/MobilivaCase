using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.RabbitMQ
{
    public class RabbitMQConsumer
    {
        public void Get()
        {
            string list = string.Empty;
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
                    queue: "bilgilendirme-mesajlari",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var ebcKuyruklar = new EventingBasicConsumer(chnKanal);

                ebcKuyruklar.Received += (model, mq) =>
                {
                    var MesajGovdesi = mq.Body;
                    list = Encoding.UTF8.GetString(MesajGovdesi.ToArray());
                };

                chnKanal.BasicConsume
                (
                    queue: "bilgilendirme-mesajlari",
                    autoAck: false, // true ise mesaj otomatik olarak kuyruktan silinir
                    consumer: ebcKuyruklar
                );
            }
        }
    }
}
