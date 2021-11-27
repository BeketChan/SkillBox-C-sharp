using System.Collections.ObjectModel;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using System.Windows;
using System.Threading.Tasks;

namespace MyBotLib
{
    public class MyBot
    {
        #region Конструкторы
        public MyBot()
        {
            token = "2146720225:AAE6Ui0GcmJaseT2Mdq8iktVjccL3xaXaVk";
            chatId = 866844709;
            bot = new TelegramBotClient(token);
            cts = new CancellationTokenSource();
            receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { } // receive all update types
            };
            dinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            messages = new ObservableCollection<MyMessage>();

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

        public ObservableCollection<MyMessage> messages { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Отправка сообщения в определёй чат.
        /// </summary>
        /// <param name="mes">Сообщение.</param>
        /// <returns></returns>
        public async Task SendMessage(MyMessage mes)
        {
            await bot.SendTextMessageAsync(
                chatId: mes.IdChat,
                text: mes.TextMes,
                cancellationToken: cts.Token);
        }

        /// <summary>
        /// Отправка чообщений ы чат по умолчанию.
        /// </summary>
        /// <param name="mes">Сообщение.</param>
        /// <returns></returns>
        public async Task SendMessage(string mes)
        {
            await bot.SendTextMessageAsync(
                chatId: chatId,
                text: mes,
                cancellationToken: cts.Token);
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

            long chatId = update.Message.Chat.Id;
            int mesId = update.Message.MessageId;
            DateTime dateMes = update.Message.Date;
            string fName = update.Message.From.FirstName != null ? update.Message.From.FirstName : "";
            string mesText = update.Message.Text != null ? update.Message.Text : "";

            MyMessage mm = new MyMessage(chatId, mesId, dateMes, fName, mesText);
            messages.Add(mm);

            switch (mesText)
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
                        if (mesText != null) await SendFile(mesText);
                    }
                    catch {}
                    break;
            }

            //Message sentMessage = await botClient.SendTextMessageAsync(
            //    chatId: chatId,
            //    text: $"You said:\n{mesText}",
            //    cancellationToken: cancellationToken);
        }

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
            MyMessage mm = new MyMessage(chatId, 0, DateTime.Now, "", text1);
            Task t1 = SendMessage(mm);
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
        /// Отображение списка доступных для скачивания файлов.
        /// </summary>
        void FileList()
        {
            string text1 = "";
            foreach (string type in fileType)
            {
                FileInfo[] fileNames = dinfo.GetFiles(type);
                foreach (FileInfo file in fileNames) text1 += $"{file.Name}\n";
            }

            MyMessage mm = new MyMessage(chatId, 0, DateTime.Now, "", text1);
            Task t1 = SendMessage(mm);
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

        #endregion
    }

    public class MyMessage
    {
        #region Свойства

        /// <summary>
        /// ID чата
        /// </summary>
        public long IdChat { get; set; }

        /// <summary>
        /// ID сообщения
        /// </summary>
        public int IdMes { get; set; }

        /// <summary>
        /// Дата сообщения
        /// </summary>
        public DateTime DateTimeMes { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string TextMes { get; set; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Базовый коструктор.
        /// </summary>
        public MyMessage()
        {
            IdChat = 0;
            IdMes = 0;
            DateTimeMes = DateTime.Now;
            FirstName = "";
            TextMes = "";
        }

        /// <summary>
        /// Полный конструктор.
        /// </summary>
        /// <param name="IdChat">ID чата.</param>
        /// <param name="IdMes">ID сообщения.</param>
        /// <param name="DateTimeMes">Дата сообщения.</param>
        /// <param name="FirstName">Имя отправителя.</param>
        /// <param name="TextMes">Текст сообщения.</param>
        public MyMessage(long IdChat, int IdMes, DateTime DateTimeMes, string FirstName, string TextMes)
        {
            this.IdChat = IdChat;
            this.IdMes = IdMes;
            this.DateTimeMes = DateTimeMes;
            this.FirstName = FirstName;
            this.TextMes = TextMes;
        }

        /// <summary>
        /// Этот конструктор добавила студия. Зачем ?
        /// </summary>
        /// <param name="v"></param>
        //public static implicit operator MyMessage(Message v)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}