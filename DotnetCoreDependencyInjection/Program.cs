using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var build = new ConfigurationBuilder();
            BuildConfig(build);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(build.Build())
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .CreateLogger();

Log.Logger.Information("Application starts here");

var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IGreetingServices,GreetingServices>();
               }).UseSerilog()
                 .Build();

var svc = ActivatorUtilities.CreateInstance<GreetingServices>(host.Services);

svc.Run();
    static void BuildConfig(IConfigurationBuilder builder)
    {
    builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables();
    }
    


