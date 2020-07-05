using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class LoginCommand : Command
    {
        public override string Name => "login";

        public override bool Contains(Message message)
        {
            if(message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Enter login");
        }
    }
}
