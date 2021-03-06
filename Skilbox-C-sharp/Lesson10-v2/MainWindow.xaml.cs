using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyBotLib;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Newtonsoft.Json;


namespace Lesson10_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyBotWPF mBot;
        MyMessage mm;

        public MainWindow()
        {
            InitializeComponent();

            mBot = new MyBotWPF(this);

            GoBot();

            IncomingListBox.ItemsSource = mBot.messages;

        }

        /// <summary>
        /// Стартовое приветствие.
        /// </summary>
        /// <returns></returns>
        async void GoBot()
        {
            var me = await mBot.bot.GetMeAsync();
            await mBot.SendMessage($"Привет ! Меня зовут @{me.FirstName}. Чтобы узнать список возможных комманд введите '/help'");
        }

        private async void SendMessageBotton_Click(object sender, RoutedEventArgs e)
        {
            if (InfoTextBlock.Text != "") await mBot.SendMessage(MessageTextBox.Text, mm.IdMes);
            else await mBot.SendMessage(MessageTextBox.Text);
        }

        private void LoadLogButton_Click(object sender, RoutedEventArgs e)
        {
            mBot.messages.Clear();
            ObservableCollection<MyMessage> log = JsonConvert.DeserializeObject<ObservableCollection<MyMessage>>(System.IO.File.ReadAllText("log.txt"));
            foreach (var message in log) mBot.messages.Add(message);
        }

        private void SaveLogButton_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText("log.txt", JsonConvert.SerializeObject(mBot.messages, Formatting.Indented));
        }
        private void IncomingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                mm = IncomingListBox.SelectedItem as MyMessage;
            }
            catch
            {
                mm = new MyMessage();
            }
            
            if (mm.FirstName != null) InfoTextBlock.Text = mm.FirstName;
            else InfoTextBlock.Text = "";
        }
    }
}
