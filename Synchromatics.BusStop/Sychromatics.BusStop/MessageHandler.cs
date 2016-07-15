using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Synchromatics.Shared.Types;

namespace Sychromatics.BusStop
{
    public abstract class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var timestampIdentifier = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
            var requestMetaData = string.Format("{0} {1}", request.Method, request.RequestUri);
            var response = await base.SendAsync(request, cancellationToken);
            var responseObject = JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
            await RequestMessageAsync(responseObject.CallStatus, responseObject.CorrelationID, timestampIdentifier, requestMetaData, await request.Content.ReadAsByteArrayAsync());
            await ResponseMessageAsync(responseObject.CallStatus, responseObject.CorrelationID, timestampIdentifier, requestMetaData, await response.Content.ReadAsByteArrayAsync());
            return response;
        }

        protected abstract Task RequestMessageAsync(CallStatus callStatus, string correlationId, string timestampIdentifier, string requestInfo, byte[] message);
        protected abstract Task ResponseMessageAsync(CallStatus callStatus, string correlationId, string timestampIdentifier, string requestInfo, byte[] message);
    }
}