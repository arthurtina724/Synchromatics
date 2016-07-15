namespace Synchromatics.BusStop.Contract
{
    public class RouteArrivalTimes
    {
        public int RouteNumber { get; set; }
        public int StopNumber { get; set; }
        public int[] MinutesFrom { get; set; }

    }
}