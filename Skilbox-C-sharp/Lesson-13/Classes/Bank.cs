using Lesson_13.Classes.Accaunt_Classes;
using Lesson_13.Classes.Klients_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Lesson_13.Classes
{
    public class Bank
    {
        #region Поля

        /// <summary>
        /// Путь к данным.
        /// </summary>
        string path = "Bank.json";

        /// <summary>
        /// Список клиентов банка.
        /// </summary>
        List<Klient<Accaunt>> klients;

        /// <summary>
        /// Список типов клиентов.
        /// </summary>
        List<string> klientType = new List<string> { "Физ.клиент", "Физ.клиент VIP" };


        #endregion

        #region Свойства

        /// <summary>
        /// Работа со списком клиентов.
        /// </summary>
        public ObservableCollection<Klient<Accaunt>>? Klients
        {
            get
            {
                if (klients != null)
                {
                    ObservableCollection<Klient<Accaunt>> vs = new ObservableCollection<Klient<Accaunt>>();
                    foreach (Klient<Accaunt> E in klients)
                        vs.Add(E);
                    return vs;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    klients.Clear();
                    foreach (Klient<Accaunt> E in value)
                        klients.Add(E);
                }
            }
        }

        /// <summary>
        /// Получить список типов клиентов.
        /// </summary>
        public ObservableCollection<string> KlientType
        {
            get
            {
                ObservableCollection<string> vs = new ObservableCollection<string>();
                foreach (string E in klientType)
                    vs.Add(E);
                return vs;
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Основной конструктор.
        /// </summary>
        public Bank()
        {
            klients = new List<Klient<Accaunt>>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        public void Save()
        {
            var jset = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string save = JsonConvert.SerializeObject(Klients, jset);
            File.WriteAllText(path, save);
        }

        /// <summary>
        /// Загрузить данные.
        /// </summary>
        public ObservableCollection<Klient<Accaunt>> Load()
        {
            var jset = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            string load = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ObservableCollection<Klient<Accaunt>>>(load, jset);
        }

        /// <summary>
        /// Добавить нового клиента.
        /// </summary>
        /// <param name="klientName">Имя клиента.</param>
        /// <param name="klientType">Тип клиента.</param>
        public void AddKlient(string klientName, string klientType)
        {
            Klient<Accaunt> newK;
            switch (klientType)
            {
                case "Физ.клиент":
                    newK = new Individual(klientName);
                    klients.Add(newK);
                    break;
                case "Физ.клиент VIP":
                    newK = new IndividualVip(klientName);
                    klients.Add(newK);
                    break;
            }
        }

        /// <summary>
        /// Добавляем счёт клиенту.
        /// </summary>
        /// <param name="currentKlient">Клиент.</param>
        /// <param name="accName">Новый счёт.</param>
        public void AddKlientAcc(Klient<Accaunt> currentKlient, string accName)
        {
            Accaunt acc = currentKlient.NewAcc(accName);

            //var serializedParent = JsonConvert.SerializeObject(acc);
            //Deposit acc2 = JsonConvert.DeserializeObject<Deposit>(serializedParent);

            currentKlient.Deposits.Add(acc);
        }


        #endregion
    }
}
