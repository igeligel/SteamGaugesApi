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
        private readonly Client _client;

        public Fixture1Test()
        {
            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler>
            {
                CallBase = true
            };
            var httpCliet = new HttpClient(fakeHttpMessageHandler.Object);
            string json;
            using (var r = new StreamReader("./fixtures/fixture-1.json"))
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
            Assert.IsTrue(response.SteamCommunity.Online);
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

        [TestMethod]
        public void SteamStoreOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(response.SteamStore.Online);
        }

        [TestMethod]
        public void SteamStoreResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(28, response.SteamStore.ResponseTime);
        }

        [TestMethod]
        public void SteamStoreResponseNoError()
        {
            var response = _client.Get();
            Assert.AreEqual("No Error", response.SteamStore.Error);
        }

        [TestMethod]
        public void SteamUserInterfaceOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(response.SteamUserInterface.Online);
        }

        [TestMethod]
        public void SteamUserInterfaceResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(17, response.SteamUserInterface.ResponseTime);
        }

        [TestMethod]
        public void SteamUserInterfaceResponseNoError()
        {
            var response = _client.Get();
            Assert.AreEqual("No Error", response.SteamUserInterface.Error);
        }

        [TestMethod]
        public void TestTeamFortressStressTest()
        {
            var response = _client.Get();
            Assert.IsFalse(response.TeamFortressSystemInterface.StressTest);
        }

        [TestMethod]
        public void TeamFortressEconomyItemsInterfaceNotOnline()
        {
            var response = _client.Get();
            Assert.IsFalse(
                response
                    .EconomyItemsInterFace
                    .TeamFortressEconomyItemsInterface
                    .Online
            );
        }

        [TestMethod]
        public void TeamFortressEconomyItemsInterfaceResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(
                56,
                response
                    .EconomyItemsInterFace
                    .TeamFortressEconomyItemsInterface
                    .ResponseTime
            );
        }

        [TestMethod]
        public void TeamFortressEconomyItemsInterfaceError()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "503 Service Unavailable",
                response
                    .EconomyItemsInterFace
                    .TeamFortressEconomyItemsInterface
                    .Error
            );
        }

        [TestMethod]
        public void DotaEconomyItemsInterfaceOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(
                response
                    .EconomyItemsInterFace
                    .DotaEconomyInterface
                    .Online
            );
        }

        [TestMethod]
        public void DotaEconomyItemsInterfaceResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(
                28,
                response
                    .EconomyItemsInterFace
                    .DotaEconomyInterface
                    .ResponseTime
            );
        }

        [TestMethod]
        public void DotaEconomyItemsInterfaceNoError()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "No Error",
                response
                    .EconomyItemsInterFace
                    .DotaEconomyInterface
                    .Error
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveEconomyItemsInterfaceNotOnline()
        {
            var response = _client.Get();
            Assert.IsFalse(
                response
                    .EconomyItemsInterFace
                    .CounterStrikeGlobalOffensiveEconomyInterface
                    .Online
            );
        }

        [TestMethod]
        public void
            CounterStrikeGlobalOffensiveEconomyItemsInterfaceResponseTime()
        {
            var response = _client.Get();
            Assert.AreEqual(
                32,
                response
                    .EconomyItemsInterFace
                    .CounterStrikeGlobalOffensiveEconomyInterface
                    .ResponseTime
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveEconomyItemsInterfaceNullError()
        {
            var response = _client.Get();
            Assert.IsNull(
                response
                    .EconomyItemsInterFace
                    .CounterStrikeGlobalOffensiveEconomyInterface
                    .Error
            );
        }
    }
}
