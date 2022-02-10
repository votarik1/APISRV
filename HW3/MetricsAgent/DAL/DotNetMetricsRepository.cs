using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.DAL
{
    public class DotNetMetricsRepository : IRepository<DotNetMetrics>
    {
        public void Create(DotNetMetrics item)
        {
            return;
        }

        public void Delete(int id)
        {
            return;
        }

        public IList<DotNetMetrics> GetAll()
        {
            return null;
        }

        public DotNetMetrics GetById(int id)
        {
            return null;
        }

        public void Update(DotNetMetrics item)
        {
            return;
        }
    }
}
