using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.DAL
{
    public class NetworkMetricsRepository : IRepository<NetworkMetrics>
    {
        public void Create(NetworkMetrics item)
        {
            return;
        }

        public void Delete(int id)
        {
            return;
        }

        public IList<NetworkMetrics> GetAll()
        {
            return null;
        }

        public NetworkMetrics GetById(int id)
        {
            return null;
        }

        public void Update(NetworkMetrics item)
        {
            return;
        }
    }
}
