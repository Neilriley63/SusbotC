using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using SusbotC.Services;
using System.Net.NetworkInformation;

namespace SusbotCCore
{
    public class SusbotC
    {
        //private CommandHandler _handler;
        private IConfigurationRoot _config;

        public async Task StartAsync()
        {
            //Create the configuration
            var _builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "config.json");
            _config = _builder.Build();

            //Configure services
            var services = new ServiceCollection()
                .AddSingleton(new DiscordShardedClient(new DiscordSocketConfig
                {
                    //LogLevel = LogSeverity.Debug,
                    LogLevel = LogSeverity.Verbose,
                    MessageCacheSize = 1000
                }))
                .AddSingleton(_config)
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    DefaultRunMode = RunMode.Async,
                    LogLevel = LogSeverity.Verbose,
                    CaseSensitiveCommands = false,
                    ThrowOnError = false
                }))
                .AddHttpClient()
                .AddSingleton<CommandHandler>()
                .AddSingleton<StartupService>()
                //.AddSingleton<GiphyApi>()
                .AddSingleton<LoggingService>()
                .AddSingleton<PingGoogle>();

            //Add logging      
            ConfigureServices(services);

            //Build services
            var serviceProvider = services.BuildServiceProvider();

            //Instantiate logger/tie-in logging
            serviceProvider.GetRequiredService<LoggingService>();

            //Start the bot
            await serviceProvider.GetRequiredService<StartupService>().StartAsync();

            //Load up services
            serviceProvider.GetRequiredService<CommandHandler>();
            //serviceProvider.GetRequiredService<UserInteraction>();            

            //Block this program until it is closed.
            await Task.Delay(-1);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Add SeriLog
            //services.AddLogging(configure => configure.AddSerilog());
            //Remove default HttpClient logging as it is extremely verbose
            services.RemoveAll<IHttpMessageHandlerBuilderFilter>();
            //Configure logging level              
            var logLevel = Environment.GetEnvironmentVariable("NJA_LOG_LEVEL");
            var level = Serilog.Events.LogEventLevel.Error;
            if (!string.IsNullOrEmpty(logLevel))
            {
                switch (logLevel.ToLower())
                {
                    case "error":
                        {
                            level = Serilog.Events.LogEventLevel.Error;
                            break;
                        }
                    case "info":
                        {
                            level = Serilog.Events.LogEventLevel.Information;
                            break;
                        }
                    case "debug":
                        {
                            level = Serilog.Events.LogEventLevel.Debug;
                            break;
                        }
                    case "crit":
                        {
                            level = Serilog.Events.LogEventLevel.Fatal;
                            break;
                        }
                    case "warn":
                        {
                            level = Serilog.Events.LogEventLevel.Warning;
                            break;
                        }
                    case "trace":
                        {
                            level = Serilog.Events.LogEventLevel.Debug;
                            break;
                        }
                }
            }
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("logs/susbot.log", rollingInterval: RollingInterval.Day)
                    .WriteTo.Console()
                    .MinimumLevel.Is(level)
                    .CreateLogger();
        }
    }

}
