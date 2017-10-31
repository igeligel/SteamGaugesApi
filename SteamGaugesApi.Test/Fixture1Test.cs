using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SteamGaugesApi.Core;
using SteamGaugesApi.Core.Models;

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

        [TestMethod]
        public void TeamFortressGameCoordinatorOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
                    .Online
            );
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorEmptySchema()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "",
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
                    .Schema
            );
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorNoError()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "No Error",
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
                    .Error
            );
        }

        private static Score GetWarScore(
            GameCoordinatorInterface gameCoordinatorInterface, int side
        )
        {
            return
                gameCoordinatorInterface
                    .Statistics
                    .WarScore
                    .FirstOrDefault(
                        e => e.Side == side
                    )
                    ?.Score;
        }

        private static Score GetFirstWarScore(
            GameCoordinatorInterface gameCoordinatorInterface
        )
        {
            return GetWarScore(gameCoordinatorInterface, 0);
        }

        private static Score GetSecondWarScore(
            GameCoordinatorInterface gameCoordinatorInterface
        )
        {
            return GetWarScore(gameCoordinatorInterface, 1);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorFirstWarScoreLow()
        {
            var response = _client.Get();
            var firstSideScore = GetFirstWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.AreEqual(5072919, firstSideScore.Low);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorFirstWarScoreHigh()
        {
            var response = _client.Get();
            var firstSideScore = GetFirstWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.AreEqual(0, firstSideScore.High);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorFirstWarScoreIsUnsigned()
        {
            var response = _client.Get();
            var firstSideScore = GetFirstWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.IsTrue(firstSideScore.Unsigned);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorSecondWarScoreLow()
        {
            var response = _client.Get();
            var firstSideScore = GetSecondWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.AreEqual(6422457, firstSideScore.Low);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorSecondWarScoreHigh()
        {
            var response = _client.Get();
            var firstSideScore = GetSecondWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.AreEqual(0, firstSideScore.High);
        }

        [TestMethod]
        public void TeamFortressGameCoordinatorSecondWarScoreIsUnsigned()
        {
            var response = _client.Get();
            var firstSideScore = GetSecondWarScore(
                response
                    .SteamGameCoordinationInterface
                    .TeamFortressGameCoordinatorInterface
            );
            Assert.IsTrue(firstSideScore.Unsigned);
        }

        [TestMethod]
        public void DotaGameCoordinatorIsOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(
                response
                    .SteamGameCoordinationInterface
                    .DotaGameCoordinatorInterface
                    .Online
            );
        }

        [TestMethod]
        public void DotaGameCoordinatorNoError()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "No Error",
                response
                    .SteamGameCoordinationInterface
                    .DotaGameCoordinatorInterface
                    .Error
            );
        }

        [TestMethod]
        public void DotaGameCoordinatorPlayersSearching()
        {
            var response = _client.Get();
            Assert.AreEqual(
                26629,
                response
                    .SteamGameCoordinationInterface
                    .DotaGameCoordinatorInterface
                    .Statistics
                    .PlayersSearching
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorIsOnline()
        {
            var response = _client.Get();
            Assert.IsTrue(
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Online
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorNoError()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "No Error",
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Error
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorPlayerSearching()
        {
            var response = _client.Get();
            Assert.AreEqual(
                10691,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .PlayersSearching
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorAverageWait()
        {
            var response = _client.Get();
            Assert.AreEqual(
                71788,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .AverageWaitTime
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorOngoingMatches()
        {
            var response = _client.Get();
            Assert.AreEqual(
                28871,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .OnGoingMatches
            );
        }

        [TestMethod]
        public void
            CounterStrikeGlobalOffensiveGameCoordinatorServersAvailable()
        {
            var response = _client.Get();
            Assert.AreEqual(
                158632,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .ServersAvailable
            );
        }

        [TestMethod]
        public void
            CounterStrikeGlobalOffensiveGameCoordinatorServersOnline()
        {
            var response = _client.Get();
            Assert.AreEqual(
                251099,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .ServersOnline
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorMenuUrl()
        {
            var response = _client.Get();
            Assert.AreEqual(
                "",
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .MenuUrl
            );
        }

        [TestMethod]
        public void CounterStrikeGlobalOffensiveGameCoordinatorPlayersOnline()
        {
            var response = _client.Get();
            Assert.AreEqual(
                615861,
                response
                    .SteamGameCoordinationInterface
                    .CounterStrikeGlobalOffensiveGameCoordinatorInterface
                    .Statistics
                    .PlayersOnline
            );
        }
    }
}
