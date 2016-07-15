namespace Synchromatics.BusStop.Model
{
    public interface IRouteLocation
    {
        int RouteNumber { get; set; }
        IStop Stop { get; set; }
        IArrivalTime[] ArrivalTime { get; set; }
    }
}