using Core.Interfaces;
using Core.Models;
using Core.Models.DTO.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Core.DAL
{
    public class CpuMetricsRepository : IRepository<CpuMetric>
    {
        private string connectionString = @"Data Source=metrics.db; Version=3; Pooling=True; Max Pool Size=100;";


        public void Create(CpuMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)", new { value = item.Value, time = item.Time.TotalSeconds });
            }
        }



        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id", new { id = id });
            }
        }

        public IList<CpuMetric> GetAll()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<CpuMetric> cpuMetrics = connection.Query<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
                return cpuMetrics;
            }

        }
       

        public CpuMetric GetById(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                CpuMetric cpuMetric = connection.QueryFirst<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id = @id", new { id = id });
                return cpuMetric;
            }
        }

        public void Update(CpuMetric item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id", new { value = item.Value, time = item.Time.TotalSeconds, id = item.ID });
            }
        }

        public IList<CpuMetric> GetByTime(double timeFrom, double timeTo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                List<CpuMetric> cpuMetrics = connection.Query<CpuMetric>("SELECT id, time, value FROM cpumetrics WHERE time>@timeFrom AND time<@timeTo", new { timeFrom = timeFrom, timeTo = timeTo }).ToList();
                return cpuMetrics;
            }
        }

        public TimeSpan GetLastTimeSpan()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                if (connection.QueryFirst<bool>("SELECT EXISTS(Select* FROM cpumetrics)"))
                {
                    int maxTime = connection.QueryFirst<int>("Select Time FROM cpumetrics WHERE \"Time\" = (SELECT MAX(\"Time\") FROM cpumetrics)");
                    return TimeSpan.FromSeconds(maxTime);
                }
                return TimeSpan.FromSeconds(0);
            }
        }

    }
}
