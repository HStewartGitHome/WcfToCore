using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Client;
using Shared.Interfaces;
using Wcf5.Shared.ClientModels;

namespace WasmWcf.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldServiceController : Controller
    {
        private readonly ILogger<HelloWorldServiceController> _logger;

        public HelloWorldServiceController(ILogger<HelloWorldServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public DetailModel Get(string param)
        {
            string address = "http://{0}:8080/hello";
            if (param == "soap")
                address = "http://{0}:5050/Service.svc";

            DetailObject details = RunClient.Execute(address, "From Blazor Webassembly Server");

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