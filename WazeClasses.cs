using System;
using System.Threading.Tasks;
using System.Configuration;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;

using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Threading;

namespace WazeDownloader
{
    public static class WazeDownloadRunner
    {
        public static void Main(string[] args)
        {
            var wds = new WazeDownloadService();
            wds.StartTimer();
            Console.ReadKey();
        }
    }

    public partial class WazeDownloadService : ServiceBase
    {
        DateTime _nextRunTime;
        CancellationTokenSource tokenSource;

        public WazeDownloadService()
        {

        }

        protected override void OnStart(string[] args)
        {
            StartTimer();
        }

        // Source: https://stackoverflow.com/a/38886665 (Peter Duniho, 2016)
        public void StartTimer()
        {
            tokenSource = new CancellationTokenSource();
            DateTime startTime = RoundCurrentToNextFiveMinutes();

            Task timerTask = RunPeriodically(RunTask,
                startTime, TimeSpan.FromMinutes(2), tokenSource.Token);
        }

        async Task RunPeriodically(Action action,
            DateTime startTime, TimeSpan interval, CancellationToken token)
        {

            _nextRunTime = startTime;

            while (true)
            {
                TimeSpan delay = _nextRunTime - DateTime.UtcNow;

                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, token);
                }

                action();
                _nextRunTime += interval;
            }
        }

        DateTime RoundCurrentToNextFiveMinutes()
        {
            DateTime now = DateTime.UtcNow,
                result = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            return result.AddMinutes(((now.Minute / 2) + 1) * 2);
        }

        public void RunTask()
        {
            try
            {
                // Lets download the JSON file
                string jsonString;
                using (System.Net.WebClient w = new System.Net.WebClient())
                {
                    jsonString = w.DownloadString(ConfigurationManager.AppSettings["WazeDownloadURL"]);
                }
                Console.WriteLine(jsonString);

                var welcome = WazeDownload.FromJson(jsonString);
                var connectionString = ConfigurationManager.ConnectionStrings["WazeDownloader.WazeDownloadContext"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dbo.WazeDownloadsRaw (FullText) VALUES (@title)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", jsonString);
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }

                using (var db = new WazeDownloadContext())
                {
                    db.WazeDownloads.Add(welcome);
                    db.SaveChanges();
                }
            }
            catch
            {
            }

        }

        protected override void OnStop()
        {
            tokenSource.Cancel();
        }
    }
}

