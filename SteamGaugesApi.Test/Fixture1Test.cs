using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SteamGaugesApi.Core;

namespace SteamGaugesApi.Test
{
    [TestClass]
    public class Fixture1Test
    {
        private readonly Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private readonly Client _client;

        public Fixture1Test()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler>
            {
                CallBase = true
            };
            var httpCliet = new HttpClient(_fakeHttpMessageHandler.Object);
            string json;
            using (var r = new StreamReader("./fixtures/fixture-1.json"))
            {
                json = r.ReadToEnd();
            }
            _fakeHttpMessageHandler
                .Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content =
                            new StringContent(json)
                    });

            _client = new Client(httpCliet);
        }

        [TestMethod]
        public void SteamInterfaceOnline()
        {
            var response = _client.Get();
            Assert.AreEqual(true, response.SteamClientInterface.Online);
        }

        [TestMethod]
        public void SteamCommunityOnline()
        {
            var response = _client.Get();
            Assert.AreEqual(true, response.SteamCommunity.Online);
        }

        [TestMethod]
        public void SteamCommunityResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(13, response.SteamCommunity.ResponseTime);
        }

        [TestMethod]
        public void SteamCommunityResponseNoError()
        {
            var response = _client.Get();
            Assert.AreEqual("No Error", response.SteamCommunity.Error);
        }
    }
}
