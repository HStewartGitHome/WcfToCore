

using System;
using Shared.Interfaces;

namespace Shared.Models
{
  
    public class HelloWorldService : IHelloWorldService
    {
        private static int Counter = 1;

    

        public string SayHello(string name)
        {
            return string.Format($"Hello, {name}");
        }

        public string SayFrom()
        {
            return "SoapCoreHost";
        }

        public DetailObject GetDetailObject(string name)
        {
            DetailObject details = new()
            {
                NameString = name,
                HelloString = SayHello(name),
                FromString = SayFrom(),
                Count = Counter++
            };

            string message = $"Hello {details.HelloString} From: {details.FromString} Name: {details.NameString} Count: {details.Count}";
            Console.WriteLine(message);

            return details;
        }
    }
}
