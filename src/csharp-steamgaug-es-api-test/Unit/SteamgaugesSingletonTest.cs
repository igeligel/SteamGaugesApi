using csharp_steamgaug_es_api_core.Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csharp_steamgaug_es_api_test.Integration
{
    [TestClass]
    public class SteamgaugesSingletonTest
    {
        [TestMethod]
        public void CheckOfflineStatus()
        {
            bool onlineStatus =  SteamgaugesManager.Instance.IsOnline(11);
            Assert.IsFalse(onlineStatus);
        }

        [TestMethod]
        public void CheckOnlineStatus()
        {
            bool onlineStatus = SteamgaugesManager.Instance.IsOnline(1);
            Assert.IsTrue(onlineStatus);
        }
    }
}
