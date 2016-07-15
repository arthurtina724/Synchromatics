using System;
using System.Net;
using System.Web.Http;
using Synchromatics.BusStop.Model;
using Synchromatics.Shared.Types;

namespace Synchromatics.BusStop.Logic.Controllers
{
    public class StopsController : BaseController
    {
        private readonly IArrivalTimeHandler _handler;

        public StopsController(IArrivalTimeHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("stops/{stopId}/arrivals")]
        public IHttpActionResult GetArrivalTimesForGivenStop(int stopId)
        {
            var check = RequestValidator.CheckArrivalTimeRequest(stopId);
            if (check != null && check.CallStatus == CallStatus.Failed)
                return Content(HttpStatusCode.BadRequest, check);

             var arrivalTimeHandlerReq = new ArrivalTimeHandlerRequest
            {
                StopNumber = stopId,
                CorrelationID = Guid.NewGuid().ToString()
            };
            var addNewEventHandlerResponse = _handler.GetArrivalTimes(arrivalTimeHandlerReq);
            var addNewEventResponse = addNewEventHandlerResponse;
            return
                Content(
                    addNewEventResponse.CallStatus == CallStatus.Succeeded
                        ? HttpStatusCode.OK
                        : HttpStatusCode.InternalServerError, addNewEventResponse);
        }
    }
}
