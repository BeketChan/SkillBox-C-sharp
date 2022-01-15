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
        //List<Klient<Accaunt>> klients;
        List<Klient> klients;

        /// <summary>
        /// Список типов клиентов.
        /// </summary>
        List<string> klientType = new List<string> { "Физ.клиент", "Физ.клиент VIP" };

        #endregion

        #region Свойства

        /// <summary>
        /// Работа со списком клиентов.
        /// </summary>
        public ObservableCollection<Klient>? Klients
        {
            get
            {
                if (klients != null)
                {
                    ObservableCollection<Klient> vs = new ObservableCollection<Klient>();
                    foreach (Klient E in klients)
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
                    foreach (Klient E in value)
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
            klients = new List<Klient>();
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
        public ObservableCollection<Klient> Load()
        {
            var jset = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            string load = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ObservableCollection<Klient>>(load, jset);
        }

        /// <summary>
        /// Добавить нового клиента.
        /// </summary>
        /// <param name="klientName">Имя клиента.</param>
        /// <param name="klientType">Тип клиента.</param>
        public Klient AddKlient(string klientName, string klientType)
        {
            Klient newK;
            switch (klientType)
            {
                case "Физ.клиент VIP":
                    newK = new IndividualVip(klientName);
                    klients.Add(newK);
                    break;
                default:
                    newK = new Individual(klientName);
                    klients.Add(newK);
                    break;
            }
            return newK;
        }

        
        #endregion
    }
}
