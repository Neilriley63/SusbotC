using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace SusbotC.Services
{
    public class StartupService
    {
        private CommandHandler _handler;
        private IConfigurationRoot _config;
        private DiscordSocketClient _client;

        public async Task StartupServiceAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            var token = "NzY5MzgwMTA4MDA2OTgxNjYy.X5OLEA.G_yOJju8hRaJjHTT4rHYprc-R7M";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
