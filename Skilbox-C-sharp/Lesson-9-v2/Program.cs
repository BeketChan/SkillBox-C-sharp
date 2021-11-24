using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Lesson_9_v2;

#region Основное тело программы.

MyBot mBot = new MyBot();
Task task;

mBot.bot.StartReceiving(
    mBot.HandleUpdateAsync,
    mBot.HandleErrorAsync,
    mBot.receiverOptions,
    cancellationToken: mBot.cts.Token);

var me = await mBot.bot.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");

task = mBot.SendMessage($"Привет ! Меня зовут @{me.FirstName}. Чтобы узнать список возможных комманд введите '/help'");




Console.ReadLine();
mBot.cts.Cancel();
# endregion

