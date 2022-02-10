using MetricsAgent.Jobs.DTO;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules)            
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobSchedules = jobSchedules;
        }
        public IScheduler Scheduler { get; set; }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var jobShedule in _jobSchedules)
            {
                IJobDetail job = CreateJobDetail(jobShedule);
                ITrigger trigger = CreateTrigger(jobShedule);
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJobDetail(JobSchedule jobShedule)
        {
            var jobType = jobShedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobType.FullName)
                .WithDescription(jobType.Name)
                .Build();

        }

        private static ITrigger CreateTrigger(JobSchedule jobShedule)
        {
            return TriggerBuilder
            .Create()
            .WithIdentity($"{jobShedule.JobType.FullName}.trigger")
            .WithCronSchedule(jobShedule.CronExpression)
            .WithDescription(jobShedule.CronExpression)
            .Build();
        }

        
        




    }
}
