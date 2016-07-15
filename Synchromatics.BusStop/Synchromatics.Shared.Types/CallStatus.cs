using System.Runtime.Serialization;

namespace Synchromatics.Shared.Types
{
    [DataContract]
    public enum CallStatus //nick
    {
        [EnumMember]
        Failed = 0,
        [EnumMember]
        Succeeded = 1
    }
}