using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.DAL
{
    class CpuMetricsRepository : IRepository<CpuMetrics>
    {
        public void Create(CpuMetrics item)
        {
            return;
        }

        public void Delete(int id)
        {
            return;
        }

        public IList<CpuMetrics> GetAll()
        {
            return null;
        }

        public CpuMetrics GetById(int id)
        {
            return null;
        }

        public void Update(CpuMetrics item)
        {
            return;
        }
    }
}
