using StructureMap;
using Synchromatics.BusStop.Data;
using Synchromatics.BusStop.Logic.Handlers;
using Synchromatics.BusStop.Model;

namespace Sychromatics.BusStop.DependencyResolution
{
    public class BusStopRegistry : Registry
    {
        public BusStopRegistry()
        {
            For<IArrivalTimeHandler>().Use<ArrivalTimeEventHandler>();
            For<IArrivalTimeRepository>().Use<ArrivalTimeRepository>();
        }
    }
}