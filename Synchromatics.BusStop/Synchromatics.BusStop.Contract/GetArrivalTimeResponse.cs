using System;
using System.Runtime.Serialization;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Contract
{
    [DataContract]
    public class GetArrivalTimeResponse : Response
    {
        [DataMember]
        public DateTime RequestedDateTimeUtc { get; set; }

        [DataMember]
        public RouteArrivalTimes[] ArrivalTimes { get; set; }
    }
}
