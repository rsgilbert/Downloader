using Quartz;

namespace Downloader.Jobs 
{
    public class HelloJob: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Greetings from Hello");
        }
    }
}