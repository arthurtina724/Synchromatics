using System;

namespace Synchromatics.BusStop.Model
{
    public interface IArrivalTime
    {
        DateTime UTCArrivalTime { get; set; }
        int MinutesFrom { get; set; }
    }
}