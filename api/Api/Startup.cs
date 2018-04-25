namespace RDrop.Api
{

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RDrop.Api.ClientMessaging.Infrastructure;
    using RDrop.Api.ClientMessaging.Handlers;
    using RDrop.Api.ClientMessaging.Models;

    public class Startup
    {

        public IConfiguration Configuration { get; }

        public static void Main(string[] args) =>
            BuildWebHost(args).Run();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) { }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebSocketMessaging(typeof(AddDownloadHandler).Assembly, typeof(AddDownloadMessage).Assembly);
        }

    }

}