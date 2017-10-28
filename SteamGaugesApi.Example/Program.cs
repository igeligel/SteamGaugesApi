using System;
using SteamGaugesApi.Core;

namespace SteamGaugesApi.Example
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Read();
            Client client = new Client();
            var result = client.Get();
            Console.WriteLine("awdwadwa");
        }
    }
}
