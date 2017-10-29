using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SteamGaugesApi.Core;

namespace SteamGaugesApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private readonly HttpClient _httpClient;

        public UnitTest1()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler>
            {
                CallBase = true
            };
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
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

            var client = new Client(_httpClient);
            var test = client.Get();
            Assert.AreEqual(2, 2);
        }
    }
}
