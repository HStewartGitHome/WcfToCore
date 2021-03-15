using Microsoft.Extensions.Logging;
using Shared.Client;
using Shared.Interfaces;
using Wcf5.Shared.ClientModels;

namespace BlazorWcf.Client.Data
{
    public class HelloWorldService
    {
        private readonly ILogger<HelloWorldService> _logger;

        public HelloWorldService(ILogger<HelloWorldService> logger)
        {
            _logger = logger;
        }

        public DetailModel Get(string param)
        {
            string address = "http://{0}:8080/hello";
            if (param == "soap")
                address = "http://{0}:5050/Service.svc";

            DetailObject details = RunClient.Execute(address, "From Blazor Server");
            DetailModel model = new()
            {
                NameString = details.NameString,
                HelloString = details.HelloString,
                FromString = details.FromString,
                Count = details.Count
            };

            return model;
        }
    }
}