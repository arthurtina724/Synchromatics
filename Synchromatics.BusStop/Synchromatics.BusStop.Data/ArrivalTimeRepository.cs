using Synchromatics.BusStop.Model;
using System;

namespace Synchromatics.BusStop.Data
{
    public class ArrivalTimeRepository : IArrivalTimeRepository
    {
        private readonly int[] _even = {0, 2, 4, 6, 8, 0, 2, 4, 6, 8};
        private readonly int[] _odd = {5, 7, 9, 1, 3, 5, 7, 9, 1, 3};

        public IRouteLocation[] GetArrivalTimesForGivenStop(DateTime requestedTimeUtc, IStop stop)
        {
            int routeFactor;
            if ((requestedTimeUtc.Minute >= 0 && requestedTimeUtc.Minute < 15) ||
                (requestedTimeUtc.Minute >= 30 && requestedTimeUtc.Minute < 45))
            {
                routeFactor = _even[stop.StopNumber - 1];
            }
            else
            {
                routeFactor = _odd[stop.StopNumber - 1];
            }

            int minutesFrom = routeFactor - (requestedTimeUtc.Minute%10);
            var arrivalTime = new ArrivalTime {MinutesFrom = minutesFrom < 0 ? 15 + minutesFrom : minutesFrom};

            return CreateRoutes(arrivalTime, stop, requestedTimeUtc);


        }

        private IRouteLocation[] CreateRoutes(ArrivalTime arrivalTime, IStop stop, DateTime requestedTime)
        {
            var route1 = new RouteLocation {RouteNumber = 1, Stop = stop};
            route1.ArrivalTime = new[]
            {
                new ArrivalTime
                {
                    MinutesFrom = arrivalTime.MinutesFrom,
                    UTCArrivalTime = requestedTime.AddMinutes(arrivalTime.MinutesFrom)
                }, 
                new ArrivalTime
                {
                    MinutesFrom = arrivalTime.MinutesFrom + 15,
                    UTCArrivalTime = requestedTime.AddMinutes(arrivalTime.MinutesFrom + 15)
                }
            };

            var route2 = new RouteLocation { RouteNumber = 2, Stop = stop };
            route2.ArrivalTime = new[]
            {
                new ArrivalTime
                {
                    MinutesFrom = route1.ArrivalTime[0].MinutesFrom + 2,
                    UTCArrivalTime = requestedTime.AddMinutes(route1.ArrivalTime[0].MinutesFrom + 2)
                },
                new ArrivalTime
                {
                    MinutesFrom = arrivalTime.MinutesFrom + 17,
                    UTCArrivalTime = requestedTime.AddMinutes(arrivalTime.MinutesFrom + 17)
                }
            };

            var route3 = new RouteLocation { RouteNumber = 3, Stop = stop };
            route3.ArrivalTime = new[]
            {
                new ArrivalTime
                {
                    MinutesFrom = route1.ArrivalTime[0].MinutesFrom + 4,
                    UTCArrivalTime = requestedTime.AddMinutes(route1.ArrivalTime[0].MinutesFrom + 4)
                },
                new ArrivalTime
                {
                    MinutesFrom = arrivalTime.MinutesFrom + 19,
                    UTCArrivalTime = requestedTime.AddMinutes(arrivalTime.MinutesFrom + 19)
                }
            };


            return new IRouteLocation[] {route1, route2, route3};
        }
    }
}
