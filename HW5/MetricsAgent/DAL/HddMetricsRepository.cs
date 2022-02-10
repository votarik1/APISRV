using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Dapper;
using System.Data.SQLite;
using Core.Interfaces;

namespace MetricsAgent.DAL
{
    public class HddMetricsRepository : IRepository<HddMetric>
    {
        private string connectionString = @"Data Source=metrics.db; Version=3; Pooling=True; Max Pool Size=100;";
        public void Create(HddMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time.TotalSeconds });
            }
        }

        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id", new { id = id });
            }
        }

        public IList<HddMetric> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                IList<HddMetric> hddMetrics = connection.Query<HddMetric>("SELECT id, Time, Value FROM hddmetrics").ToList();
                return hddMetrics;
            }
        }

        public HddMetric GetById(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                HddMetric hddMetric = connection.QueryFirst<HddMetric>("SELECT id, Time, Value FROM hddmetrics WHERE id=@id", new { id = id });
                return hddMetric;
            }
        }

        public void Update(HddMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE hddmetrics SET value=@value, time=@time WHERE id=@id", new { value = item.Value, time = item.Time.TotalSeconds, id = item.ID });
            }
        }

        public IList<HddMetric> GetByTime(double timeFrom, double timeTo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<HddMetric> hddNetMetrics = connection.Query<HddMetric>("SELECT Id, Time, Value FROM hddmetrics WHERE time>@timeFrom AND time<@timeTo").ToList();
                return hddNetMetrics;
            }

        }
    }
}
