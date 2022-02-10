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
    public class NetworkMetricsRepository : IRepository<NetworkMetric>
    {
        private string connectionString = @"Data Source=metrics.db; Version=3; Pooling=True; Max Pool Size=100;";
        public void Create(NetworkMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO networkmetrics(value,time) VALUES(@value, @time)", new {value=item.Value, time=item.Time.TotalSeconds});
            }
        }

        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id", new { id = id });
            }
        }

        public IList<NetworkMetric> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                IList<NetworkMetric> networkMetrics = connection.Query<NetworkMetric>("SELECT id, Time, Value FROM networkmetrics").ToList();
                return networkMetrics;
            }
        }

        public NetworkMetric GetById(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                NetworkMetric networkMetric = connection.QueryFirst("SELECT id, Time, Value FROM networkmetrics WHERE id=@id", new { id = id });
                return networkMetric;
            }
        }

        public void Update(NetworkMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE networkmetrics SET value=@value, time=@time  WHERE id=@id", new {value=item.Value, time=item.Time.TotalSeconds, id=item.ID});
            }
        }

        public IList<NetworkMetric> GetByTime(double timeFrom, double timeTo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<NetworkMetric> networkMetrics = connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM networkmetrics WHERE time>@timeFrom AND time<@timeTo").ToList();
                return networkMetrics;
            }

        }
    }
}
