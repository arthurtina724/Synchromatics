using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using Synchromatics.BusStop.Contract;

namespace Synchromatics.TestClient
{
    public class ArrivalTimeProcess
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly Controller _controller;
        private readonly ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        public ArrivalTimeProcess()
        {
            _controller = new Controller();
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _controller.Run(_tokenSource.Token);
        }

        public void Stop()
        {
            _tokenSource.Cancel();
        }
    }
}

