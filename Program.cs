// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using Downloader;
using Downloader.Jobs;
using Downloader.Logging;
using Quartz;
using Quartz.Impl;

LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

Console.WriteLine("Hello, World!");

StdSchedulerFactory factory = new StdSchedulerFactory();
IScheduler scheduler = await factory.GetScheduler();

await scheduler.Start();
Console.WriteLine("Started scheduler");
IJobDetail job = JobBuilder.Create<HelloJob>()
    .WithIdentity("job1", "group1")
    .Build();
ITrigger trigger = TriggerBuilder.Create()
.WithIdentity("trigger1", "group1")
.StartNow()
.WithSimpleSchedule(x =>
    x.WithIntervalInSeconds(3)
    .RepeatForever())
.Build();

await scheduler.ScheduleJob(job, trigger);

// some sleep to show whats happening
await Task.Delay(TimeSpan.FromSeconds(10));

Console.WriteLine("Shutting down scheduler");
await scheduler.Shutdown();