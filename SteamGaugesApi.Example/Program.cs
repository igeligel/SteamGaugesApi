using System;
using SteamGaugesApi.Core;

namespace SteamGaugesApi.Example
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press a key to fetch the API...");
            Console.Read();
            var client = new Client();
            var result = client.Get();
            Console.WriteLine(
                "API was fetched. Next time debug here to get more information."
            );
        }
    }
}
