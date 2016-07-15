using System.Runtime.Serialization;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Contract
{
    [DataContract]
    public class GetArrivalTimeRequest : Request
    {
        [DataMember(Name = "StopNumber")]
        public int StopNumber { get; set; }
    }
}

