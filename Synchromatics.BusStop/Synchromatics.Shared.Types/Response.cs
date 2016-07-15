using System.Runtime.Serialization;

namespace Synchromatics.Shared.Types
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string CorrelationID { get; set; }
        [DataMember]
        public CallStatus CallStatus { get; set; }
        [DataMember]
        public Error Error { get; set; }
    }
}
