using Synchromatics.BusStop.Model;

namespace Synchromatics.BusStop.Data
{
    public class RouteLocation : IRouteLocation
    {
        public int RouteNumber { get; set; }
        public IStop Stop { get; set; }
        public IArrivalTime[] ArrivalTime { get; set; }
    }
}