using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Lesson_9_v2
{
    public class MyBot
    {
        #region Конструкторы
        public MyBot()
        {
            token = System.IO.File.ReadAllText("token.txt");
            chatId = 866844709;
            bot = new TelegramBotClient(token);
            cts = new CancellationTokenSource();
            receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { } // receive all update types
            };
            dinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        }

        #endregion

        #region Пеоля и свойства

        public string token;
        public int chatId;
        public TelegramBotClient bot;
        public CancellationTokenSource cts;
        public ReceiverOptions receiverOptions;
        DirectoryInfo dinfo;

        string[] options = { "/help = показать список команд", "/list = показать доступные для скачивания файлы (.txt, .jpg, .mp3). Для скачивания файла просто напишите его имя с расширением." };
        string[] fileType = { "*.txt", "*.mp3", "*.jpg" };

        #endregion

        #region Методы

        /// <summary>
        /// Вывод доступных опций в чат.
        /// </summary>
        void OptionList()
        {
            string text1 = "";
            for (int i = 0; i < options.Length; i++)
            {
                text1 += $"{options[i]}\n";
            }
            Task t1 = SendMessage(text1);
        }

        /// <summary>
        /// Обработка принятых из Телеграма сообщений.
        /// </summary>
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Only process text messages
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            switch (messageText)
            {
                case "/help":
                    OptionList();
                    break;
                case "/list":
                    FileList();
                    break;
                default:
                    try
                    {
                        await SendFile(messageText);
                    }
                    catch
                    {
                        
                    } 
                    break;
            }
                        
            //Message sentMessage = await botClient.SendTextMessageAsync(
            //    chatId: chatId,
            //    text: "You said:\n",
            //    cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Отправка сообщения в чат.
        /// </summary>
        /// <param name="mes">Сообщение</param>
        /// <returns></returns>
        public async Task SendMessage(string mes)
        {
            Message sentMessage = await bot.SendTextMessageAsync(
                chatId: chatId,
                text: mes,
                cancellationToken: cts.Token);
        }

        /// <summary>
        /// Отправка файлов по имени.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <returns></returns>
        public async Task SendFile(string name)
        {
            Console.WriteLine($"Отправляю файл: {name}");

            using (FileStream stream = System.IO.File.OpenRead(name))
            {
                InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, name);
                await bot.SendDocumentAsync(chatId, inputOnlineFile);
            }
        }

        /// <summary>
        /// Отлов ошибок Телеграма.
        /// </summary>
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Отображение списка доступных для скачивания файлов.
        /// </summary>
        void FileList()
        {
            string text1 = "";
            foreach(string type in fileType)
            {
                FileInfo[] fileNames = dinfo.GetFiles(type);
                foreach (FileInfo file in fileNames) text1 += $"{file.Name}\n";
            }

            Task t1 = SendMessage(text1);
        }


        

        #endregion
    }
}
