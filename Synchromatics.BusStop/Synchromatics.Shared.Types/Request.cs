using System.Runtime.Serialization;

namespace Synchromatics.Shared.Types
{
    [DataContract]
    public abstract class Request
    {
        [DataMember]
        public string CorrelationID { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Timestamp { get; set; }
    }
}