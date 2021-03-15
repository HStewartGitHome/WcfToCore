
using Shared.Interfaces;
using System;


namespace Shared.Models
{
    public class HelloWorldService : IHelloWorldService
    {
        private static int Counter = 1;

        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }

        public string SayFrom()
        {
            return "4.72 WCF SelfHost";
        }

        public DetailObject GetDetailObject(string name)
        {
            DetailObject details = new DetailObject()
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
