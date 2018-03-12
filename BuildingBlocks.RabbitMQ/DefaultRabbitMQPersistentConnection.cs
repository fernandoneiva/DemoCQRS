using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace BuildingBlocks.RabbitMQ
{
    public class DefaultRabbitMQPersistentConnection
        : IRabbitMQPersistentConnection
    {
        public bool IsConnected => throw new NotImplementedException();

        public IModel CreateModel()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool TryConnect()
        {
            throw new NotImplementedException();
        }
    }
}
