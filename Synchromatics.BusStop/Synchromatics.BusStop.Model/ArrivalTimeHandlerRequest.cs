using Synchromatics.BusStop.Contract;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Model
{
    public class ArrivalTimeHandlerRequest : Request
    {
        public int StopNumber { get; set; }

        public static explicit operator ArrivalTimeHandlerRequest(GetArrivalTimeRequest request)
        {
            if (request == null) return null;

            return new ArrivalTimeHandlerRequest
            {
                CorrelationID = request.CorrelationID,
                StopNumber = request.StopNumber
            };
        }
    }
}