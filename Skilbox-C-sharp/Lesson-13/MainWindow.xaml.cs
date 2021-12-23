using Lesson_13.Classes;
using Lesson_13.Classes.Accaunt_Classes;
using Lesson_13.Classes.Klients_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        Klient<Accaunt> currentKlient;

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
            bank.AddKlient(NewKlient.Text, currentKlientType);

            KlientList.ItemsSource = bank.Klients;
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
            currentKlient = (Klient<Accaunt>)KlientList.SelectedItem;
            CurrentKlient.Text = currentKlient.Name;
        }

        /// <summary>
        /// Добавить счёт выбранному клиенту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAcc_Click(object sender, RoutedEventArgs e)
        {
            if (NewAcc.Text == "") NewAcc.Text = "Default";
            //bank.AddKlientAcc(currentKlient, NewAcc.Text);  // не работает
            //test.Text = currentKlient.Deposits[0].Name;


            // перенёс из bank.AddKlientAcc
            //Accaunt acc = currentKlient.NewAcc(NewAcc.Text); // работает
            //test.Text = acc.Name;
            //currentKlient.Deposits.Add(acc); // не работает :(
            //test.Text = currentKlient.Deposits[0].Name;


            // ещё вариант
            Accaunt acc = currentKlient.NewAcc(NewAcc.Text);
            var serializedParent = JsonConvert.SerializeObject(acc);
            Deposit acc2 = JsonConvert.DeserializeObject<Deposit>(serializedParent);
            currentKlient.Deposits.Add(acc);   // не работает :(
            test.Text = currentKlient.Deposits[0].Name;



            //test.Text = bank.Klients[0].Deposits[0].Name;
            //test.Text = bank.Klients[0].Name;
            //test.Text = currentKlient.Name;

        }
    }
}
