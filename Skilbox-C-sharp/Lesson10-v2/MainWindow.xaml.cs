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


namespace Lesson10_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Task task;

        public MainWindow()
        {
            InitializeComponent();

            MyBotWPF mBot = new MyBotWPF(this);

            task = goBot(mBot);

            IncomingListBox.ItemsSource = mBot.messages;

        }

        /// <summary>
        /// Стартовое приветствие.
        /// </summary>
        /// <returns></returns>
        async Task goBot(MyBotWPF mBot)
        {
            var me = await mBot.bot.GetMeAsync();
            task = mBot.SendMessage($"Привет ! Меня зовут @{me.FirstName}. Чтобы узнать список возможных комманд введите '/help'");
        }



        private void SendMessageBotton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadLogButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveLogButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
