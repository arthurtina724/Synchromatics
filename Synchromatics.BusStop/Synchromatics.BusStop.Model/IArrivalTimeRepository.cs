using System;

namespace Synchromatics.BusStop.Model
{
    public interface IArrivalTimeRepository
    {
        IRouteLocation[] GetArrivalTimesForGivenStop(DateTime requestedTimeUtc, IStop stop);
    }
}