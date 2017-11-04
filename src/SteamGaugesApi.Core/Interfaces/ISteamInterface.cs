namespace SteamGaugesApi.Core.Interfaces
{
    public interface ISteamInterface : ISteamInterfaceBase
    {
        int ResponseTime { get; set; }
        string Error { get; set; }
    }
}
