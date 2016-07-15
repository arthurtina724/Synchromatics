using System;
using Synchromatics.BusStop.Model;

namespace Synchromatics.BusStop.Logic
{
    public class Coordinator
    {
        private readonly IArrivalTimeRepository _arrivalTimeRepository;
        public Coordinator(IArrivalTimeRepository repository)
        {
            _arrivalTimeRepository = repository;
        }

        public IRouteLocation[] GetArrivalTimesForGivenStop(int stopNumber, DateTime requestedDateTimeUtc)
        {
            //TODO - add more rules regarding arrival times. ie. Delays
            var routesAndArrivalTimes = _arrivalTimeRepository.GetArrivalTimesForGivenStop(requestedDateTimeUtc, new Stop {StopNumber = stopNumber});
            return routesAndArrivalTimes;
        }

        
    }
}
