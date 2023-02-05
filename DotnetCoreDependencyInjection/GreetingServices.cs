using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class GreetingServices : IGreetingServices
{
    private readonly ILogger<GreetingServices> _log;
    private readonly IConfiguration _configuration;

    public GreetingServices(ILogger<GreetingServices> log, IConfiguration configuration)
    {
        _log = log;
        _configuration = configuration;
    }



    public void Run()
    {
        for (int i = 0; i < _configuration.GetValue<int>("LoopTimes"); i++)
        {
            _log.LogInformation("Run Number {runNumber}", i);//use _log.LogError If u require warning by default
        }

    }
}
    


