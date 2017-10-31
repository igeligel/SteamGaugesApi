using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SteamGaugesApi.Test
{
    public abstract class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException("Now we can setup this method with our mocking framework");
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }
    }
}
