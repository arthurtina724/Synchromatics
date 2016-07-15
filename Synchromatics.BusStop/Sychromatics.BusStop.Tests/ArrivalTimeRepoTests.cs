using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synchromatics.BusStop.Data;
using Synchromatics.BusStop.Model;

namespace Synchromatics.BusStop.Tests
{
    [TestClass]
    public class ArrivalTimeRepoTests
    {
        [TestMethod]
        public void ShouldGetArrivalTimesFor3DifferentRoutes_Stop1()
        {
            //3:01 AM
            var repo = new ArrivalTimeRepository();
            var routelocations = repo.GetArrivalTimesForGivenStop(new DateTime(2016, 1, 1, 3, 1, 0), new MockStop { StopNumber = 1 });
            Assert.IsNotNull(routelocations);
            Assert.IsTrue(routelocations.Length == 3);
        }

        [TestMethod]
        public void ShouldGetArrivalTimesFor3DifferentRoutes_Stop5()
        {
            //7:52 AM
            var repo = new ArrivalTimeRepository();
            var routelocations = repo.GetArrivalTimesForGivenStop(new DateTime(2016, 1, 1, 7, 52, 0), new MockStop { StopNumber = 5 });
            Assert.IsNotNull(routelocations);
            Assert.IsTrue(routelocations.Length == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldGetExceptionFromSignOutOfBounds()
        {
            var repo = new ArrivalTimeRepository();
            repo.GetArrivalTimesForGivenStop(new DateTime(2016, 1, 1, 7, 52, 0), new MockStop { StopNumber = 25 });
        }

        [TestMethod]
        public void ShouldGetArrivalTimesFor3DifferentRoutes_Stop1CheckMin()
        {
            //3:01 AM
            var repo = new ArrivalTimeRepository();
            var routelocations = repo.GetArrivalTimesForGivenStop(new DateTime(2016, 1, 1, 3, 1, 0), new MockStop { StopNumber = 1 });
            Assert.IsNotNull(routelocations);
            Assert.IsTrue(routelocations.Length == 3);
            Assert.IsTrue(routelocations[0].RouteNumber == 1);
            Assert.IsTrue(routelocations[0].ArrivalTime[0].MinutesFrom == 14);
            Assert.IsTrue(routelocations[0].ArrivalTime[1].MinutesFrom == 29);
        }

    }

    public class MockStop : IStop
    {
        public int StopNumber { get; set; }
    }
}
