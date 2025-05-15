using WebAPI.Contracts;

namespace WebAPI.Services
{
    public class JobService : IJobService
    {
        private static readonly string LogFilePath = Path.Combine("Logs", "job-logs.txt");

        public void LogJobRun(string jobName)
        {
            var logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {jobName} running...{Environment.NewLine}";

            using (StreamWriter writer = new StreamWriter(LogFilePath, append: true))
            {
                writer.WriteLine(logLine);
            }
        }
    }
}
