using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Models.Commands;
using TelegramBot.Controllers;

namespace TelegramBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;

        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands => commandList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (client != null)
            {
                return client;
            }

            commandList = new List<Command>();
            commandList.Add(new StartCommand());
            commandList.Add(new LoginCommand());

            client = new TelegramBotClient(AppSettings.Token);
            string hook = string.Format(AppSettings.Url, "api/messages/update");
            Console.WriteLine(hook);
            await client.SetWebhookAsync(hook);
            return client;
        }

    }
}
