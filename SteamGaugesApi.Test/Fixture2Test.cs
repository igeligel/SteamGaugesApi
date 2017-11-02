using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SteamGaugesApi.Core;

namespace SteamGaugesApi.Test
{
    [TestClass]
    public class Fixture2Test
    {
        private readonly Client _client;

        public Fixture2Test()
        {
            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler>
            {
                CallBase = true
            };
            var httpCliet = new HttpClient(fakeHttpMessageHandler.Object);
            string json;
            using (var r = new StreamReader("./fixtures/fixture-2.json"))
            {
                json = r.ReadToEnd();
            }
            fakeHttpMessageHandler
                .Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content =
                            new StringContent(json)
                    });

            _client = new Client(httpCliet);
        }
    }
}
