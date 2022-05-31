using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.RabbitMQ
{
    public interface IRabbitMQConsumer
    {
        public bool Get();
    }
}
