using StructureMap;

namespace Sychromatics.BusStop.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(x => x.AddRegistry<BusStopRegistry>());
        }
    }
}