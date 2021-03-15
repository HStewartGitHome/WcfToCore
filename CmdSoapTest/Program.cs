
using Shared.Client;
using Shared.Interfaces;
using System;
using System.Diagnostics;

namespace CmdSoapTest
{
    internal class Program
    {
        private static void Main()
        {
            string address = "http://{0}:5050/Service.svc";
            ExecuteClientEx(address);
            Console.WriteLine("");
            ExecuteClientEx(address);
            Console.WriteLine("");
            ExecuteClientEx(address);
            Console.WriteLine("");
            address = "http://{0}:8080/hello";
            ExecuteClientEx(address);
            Console.WriteLine("");
            ExecuteClientEx(address);
            Console.WriteLine("");
            ExecuteClientEx(address);
            Console.WriteLine("");
            Console.WriteLine("Finish hit any key");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs and call WCF clients call via URL
        /// </summary>
        /// <param name="address"></param>
        ///      "http://{0}:8080/hello"        - this is address for WCF Self Host
        ///      http://{0}:5050/Service.svc"   - this is address for SoapCore Host
        private static void ExecuteClientEx(string address)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string nameString = "From CmdSoapTest";
            DetailObject details = RunClient.Execute(address, nameString);

            stopwatch.Stop();
            int time = (int)stopwatch.ElapsedMilliseconds;
            string message = $"Hello {details.HelloString} From: {details.FromString} Name: {details.NameString} Count: {details.Count} Time: {time}";
            Console.WriteLine(message);
        }
    }
}