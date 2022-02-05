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
    public class RamMetricsRepository : IRepository<RamMetric>
    {
        private string connectionString = @"Data Source=metrics.db; Version=3; Pooling=True; Max Pool Size=100;";
        public void Create(RamMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",new {value=item.Value, time=item.Time.TotalSeconds});
            }
        }

        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",new {id=id});
            }
        }

        public IList<RamMetric> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                IList<RamMetric> ramMetrics = connection.Query<RamMetric>("SELECT id, Time, Value FROM rammetrics").ToList();
                return ramMetrics;
            }
        }

        public RamMetric GetById(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                RamMetric ramMetric = connection.QueryFirst("SELECT id, Time, Value FROM rammetrics WHERE id=@id", new {id=id});
                return ramMetric;
            }
        }

        public void Update(RamMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE rammetrics SET value=@value, time=@time WHERE id=@id", new {value=item.Value, time=item.Time.TotalSeconds, id=item.ID});
            }
        }
    }
}
