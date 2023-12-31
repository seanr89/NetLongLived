﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

    
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<MyBackgroundService>();
        services.AddHostedService<Worker>();
    })
        .ConfigureLogging((context, logging) => {
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
    }).Build();

host.Run();