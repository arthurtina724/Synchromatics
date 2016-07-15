using System;
using Synchromatics.BusStop.Model;

namespace Synchromatics.BusStop.Data
{
    public class ArrivalTime : IArrivalTime
    {
        public DateTime UTCArrivalTime { get; set; }
        public int MinutesFrom { get; set; }
    }
}