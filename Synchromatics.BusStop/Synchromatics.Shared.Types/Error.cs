using System;
using System.Runtime.Serialization;

namespace Synchromatics.Shared.Types
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public Exception Exception { get; set; }
    }
}
