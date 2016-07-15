using System;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synchromatics.BusStop.Contract;
using Synchromatics.BusStop.Logic.Controllers;
using Synchromatics.BusStop.Model;

namespace Synchromatics.BusStop.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ShouldReturnFailedResponseforInvalidRequest()
        {
            var handler = new MockIArrivalTimeHandler();
            var controller = new StopsController(handler);
            var actionResult = controller.GetArrivalTimesForGivenStop(25);
            Assert.IsInstanceOfType(actionResult, typeof(NegotiatedContentResult<GetArrivalTimeResponse>));
            var response = (NegotiatedContentResult<GetArrivalTimeResponse>) actionResult;
            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }
    }

    public class MockIArrivalTimeHandler : IArrivalTimeHandler
    {
        public GetArrivalTimeResponse GetArrivalTimes(ArrivalTimeHandlerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
