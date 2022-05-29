using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void Send(string name, string mail, string message);
    }
}
