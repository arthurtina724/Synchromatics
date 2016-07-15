using Synchromatics.BusStop.Contract;

namespace Synchromatics.BusStop.Model
{
    public interface IArrivalTimeHandler
    {
        GetArrivalTimeResponse GetArrivalTimes(ArrivalTimeHandlerRequest request);
    }
}
