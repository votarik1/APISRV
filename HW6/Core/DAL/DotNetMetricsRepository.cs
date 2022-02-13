using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Dapper;
using System.Data.SQLite;
using Core.Interfaces;

namespace Core.DAL
{
    public class DotNetMetricsRepository : IRepository<DotNetMetric>
    {
        private string connectionString = @"Data Source=metrics.db; Version=3; Pooling=True; Max Pool Size=100;";
        public void Create(DotNetMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time.TotalSeconds });
            }
        }

        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM dotnetmetrics WHERE id=@id", new { id = id });
            }
        }

        public IList<DotNetMetric> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<DotNetMetric> dotNetMetrics = connection.Query<DotNetMetric>("SELECT id, Time, Value FROM dotnetmetrics").ToList();
                return dotNetMetrics;
            }
        }

        public DotNetMetric GetById(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DotNetMetric dotNetMetric = connection.QueryFirst<DotNetMetric>("SELECT id, Time, Value FROM dotnetmetrics WHERE id=@id", new { id = id });
                return dotNetMetric;
            }
        }

        public void Update(DotNetMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE dotnetmetrics SET value=@value, time=@time WHERE id=@id",new {value=item.Value, time=item.Time.TotalSeconds, id = item.ID});
            }
        }

        public IList<DotNetMetric> GetByTime(double timeFrom, double timeTo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<DotNetMetric> dotNetMetrics = connection.Query<DotNetMetric>("SELECT id, time, value FROM dotnetmetrics WHERE time>@timeFrom AND time<@timeTo", new { timeFrom = timeFrom, timeTo = timeTo }).ToList();
                return dotNetMetrics;
            }

        }

        public TimeSpan GetLastTimeSpan()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                if (connection.QueryFirst<bool>("SELECT EXISTS(Select* FROM dotnetmetrics)"))
                {
                    int maxTime = connection.QueryFirst<int>("Select Time FROM dotnetmetrics WHERE \"Time\" = (SELECT MAX(\"Time\") FROM dotnetmetrics)");
                    return TimeSpan.FromSeconds(maxTime);
                }
                return TimeSpan.FromSeconds(0);
            }
        }
    }
}
