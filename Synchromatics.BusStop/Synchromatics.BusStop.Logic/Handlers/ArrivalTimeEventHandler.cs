using System;
using System.Collections.Generic;
using System.Linq;
using Synchromatics.BusStop.Contract;
using Synchromatics.BusStop.Model;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Logic.Handlers
{
    public class ArrivalTimeEventHandler : IArrivalTimeHandler
    {
        private readonly IArrivalTimeRepository _arrivalTimeRepository;

        public ArrivalTimeEventHandler(IArrivalTimeRepository repository)
        {
            _arrivalTimeRepository = repository;
        }

        public GetArrivalTimeResponse GetArrivalTimes(ArrivalTimeHandlerRequest request)
        {
            var reqeustedTimeStamp = DateTime.Now.ToUniversalTime();
            var response = new GetArrivalTimeResponse { RequestedDateTimeUtc = reqeustedTimeStamp, CorrelationID = request.CorrelationID };
            try
            {
                //TODO - add more rules regarding arrival times. ie. Delays
                var routesAndArrivalTimes = _arrivalTimeRepository.GetArrivalTimesForGivenStop(reqeustedTimeStamp,
                    new Stop {StopNumber = request.StopNumber});

                var arrivalTimes = new List<RouteArrivalTimes>();
                foreach (var routesAndArrivalTime in routesAndArrivalTimes)
                {
                    var routeArrivals = new RouteArrivalTimes
                    {
                        RouteNumber = routesAndArrivalTime.RouteNumber,
                        StopNumber = routesAndArrivalTime.Stop.StopNumber,
                        MinutesFrom = routesAndArrivalTime.ArrivalTime.Select(t => t.MinutesFrom).ToArray()
                    };
                    arrivalTimes.Add(routeArrivals);
                }
                response.ArrivalTimes = arrivalTimes.ToArray();
                response.CallStatus = CallStatus.Succeeded;
            }
            catch (Exception ex)
            {
                response.CallStatus = CallStatus.Failed;
                response.Error = new Error() {Exception = ex, Message = "Error occured in ArrivalTimeHandler"};
            }
            return response;
        }
    }
}

