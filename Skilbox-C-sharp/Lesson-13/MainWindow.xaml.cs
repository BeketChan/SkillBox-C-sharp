using Lesson_13.Classes;
using Lesson_13.Classes.Accaunt_Classes;
using Lesson_13.Classes.Klients_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace Lesson_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank bank = new();
        string currentKlientType = "";
        Klient currentKlient;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = bank;
        }

        #region Методы

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bank.Save();
        }

        /// <summary>
        /// Загрузить данные.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            bank.Klients = bank.Load();

            KlientList.ItemsSource = bank.Klients;
        }

        #endregion

        /// <summary>
        /// Добавить клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddKlient_Click(object sender, RoutedEventArgs e)
        {
            currentKlient = bank.AddKlient(NewKlient.Text, currentKlientType);

            KlientList.ItemsSource = bank.Klients;
            KlientAccList.ItemsSource = currentKlient.Deposits;
            KlientAcc.ItemsSource = currentKlient.AccType;
        }

        /// <summary>
        /// Смена выбора типа клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlientKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KlientKind != null && KlientKind.SelectedItem != null && KlientKind.SelectedItem.ToString() != null)
            {
                currentKlientType = KlientKind.SelectedItem.ToString();
            }
            else currentKlientType = "";
        }

        /// <summary>
        /// Смена выбранного клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlientList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            currentKlient = (Klient)KlientList.SelectedItem;
            CurrentKlient.Text = $"{currentKlient.Name}, {currentKlient.Type}";
            KlientAccList.ItemsSource = currentKlient.Deposits;
            KlientAcc.ItemsSource = currentKlient.AccType;
        }

        /// <summary>
        /// Добавить счёт выбранному клиенту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAcc_Click(object sender, RoutedEventArgs e)
        {
            if (NewAcc.Text == "") NewAcc.Text = "Default";
            currentKlient.AddAcc(NewAcc.Text);
            KlientAccList.ItemsSource = currentKlient.Deposits;

            test.Text = currentKlient.Deposits[0].Name;
        }
    }
}
