using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient _bot;
        static void Main(string[] args)
        {
            _bot = new TelegramBotClient("Token for telegram");
            var me = _bot.GetMeAsync().Result;
            Console.WriteLine($"Hello World, I am {me.FirstName}");
            _bot.OnMessage += Bot_OnMessage;
            _bot.StartReceiving();
            Console.WriteLine("Press a key to exit!");
            Console.ReadKey();
            _bot.StopReceiving();
        }
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Channel ID: {e.Message.Chat.Id}\nMessage: {e.Message.Text}");

                await _bot.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "You said:\n" + e.Message.Text);

            }
        }
    }
}
