using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Interfaces;
using SoapCore;
using System.ServiceModel;
using Shared.Models;

/// <summary>
///   Startup class from SoapCore sample code
/// </summary>
namespace SoapCoreHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSoapCore();
            services.TryAddSingleton<IHelloWorldService, HelloWorldService>();
            services.AddMvc(x => x.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSoapEndpoint<IHelloWorldService>("/Service.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
            app.UseSoapEndpoint<IHelloWorldService>("/Service.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
            app.UseMvc();
        }
    }
}