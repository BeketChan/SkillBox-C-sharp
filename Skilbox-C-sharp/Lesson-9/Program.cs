using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Lesson_9
{
    internal class Program
    {
        static async Task Main()
        {
            string token = System.IO.File.ReadAllText("token.txt");
            TelegramBotClient bot = new TelegramBotClient(token);
            //bot.OnMessage += MessageListener; // не работает
            //using var cts = new CancellationTokenSource();// требует более новую версию c#

            User me = await bot.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            Console.ReadLine();
        }
    }
}
