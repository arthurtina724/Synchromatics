using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchromatics.BusStop.Contract;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Logic
{
    public class RequestValidator
    {
        public static GetArrivalTimeResponse CheckArrivalTimeRequest(int stopNumber)
        {
            if (stopNumber < 0 || stopNumber > 10)
            {

                return new GetArrivalTimeResponse
                {
                    CallStatus = CallStatus.Failed,
                    Error = new Error { Exception = new ArgumentOutOfRangeException(nameof(stopNumber)), Message = "Request is invalid!"}
                };
            }

            return new GetArrivalTimeResponse { CallStatus = CallStatus.Succeeded };
        }
    }
}
