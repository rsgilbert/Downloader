// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;

Console.WriteLine("Hello, World!");

StdSchedulerFactory factory = new StdSchedulerFactory();
IScheduler scheduler = await factory.GetScheduler();

await scheduler.Start();
Console.WriteLine("Starting scheduler");


// some sleep to show whats happening
await Task.Delay(TimeSpan.FromSeconds(10));

Console.WriteLine("Shutting down scheduler");
await scheduler.Shutdown();