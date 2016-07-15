using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Synchromatics.BusStop.Contract;

namespace Synchromatics.TestClient
{
    public class Controller
    {

        public void Run(CancellationToken token)
        {
            var tasks = new[]
            {
                DoPeriodicWorkAsync(RunAction, TimeSpan.FromSeconds(0),
                    TimeSpan.FromSeconds(60), token)
            };
            Task.WaitAll(tasks, token);
        }

        private void RunAction(CancellationToken cancellationToken)
        {
            Console.WriteLine(); 
            cancellationToken.ThrowIfCancellationRequested();

            ShowArrivalTimesForStopNumber(1);
            ShowArrivalTimesForStopNumber(2);
        }

        private void ShowArrivalTimesForStopNumber(int stopNumber)
        {
            var client = new RestClient("http://localhost:58862");
            string resource = string.Format("/stops/{0}/arrivals", stopNumber);
            var request = new RestRequest(resource, Method.GET);

            var response = client.Execute(request);
            var arrivalTimes = JsonConvert.DeserializeObject<GetArrivalTimeResponse>(response.Content);
            Console.WriteLine("Stop {0}:", arrivalTimes.ArrivalTimes[0].StopNumber);
            foreach (var arrivalTime in arrivalTimes.ArrivalTimes)
            {
                Console.WriteLine("Route {0} in {1} mins and {2} mins", arrivalTime.RouteNumber,
                    arrivalTime.MinutesFrom[0], arrivalTime.MinutesFrom[1]);
            }

            Console.WriteLine();
        }

        private static async Task DoPeriodicWorkAsync(Action<CancellationToken> action, TimeSpan dueTime,
            TimeSpan interval, CancellationToken token)
        {
            if (dueTime > TimeSpan.Zero)
                await Task.Delay(dueTime, token);

            while (!token.IsCancellationRequested)
            {
                action(token);
                if (interval > TimeSpan.Zero)
                    await Task.Delay(interval, token);
            }
        }
    }
}
