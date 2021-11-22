using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;

namespace Lesson_8
{
    internal class Program
    {
        /// <summary>
        /// Вывод опций меню в консоль.
        /// </summary>
        /// <param name="menu">Массив с пунктами меню.</param>
        static void MenuInConsol(Dictionary<int,string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
                Console.WriteLine($"{i} = {menu[i]}");
        }
        
        /// <summary>
        /// Начало работы программы.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string pathXml = "hrBase.xml", pathJson = "hrBase.json";
            int option;
            int numer = 0;
            ExpansionForConsol ExpConsol = new ExpansionForConsol();
            Company workers = new Company();

            var menu = new Dictionary<int, string>();
            menu.Add(numer++, "Закрыть программу");
            menu.Add(numer++, "Добавить сотрудника");
            menu.Add(numer++, "Удалить сотрудника");
            menu.Add(numer++, "Отобразить список сотрудников");
            menu.Add(numer++, "Упорядочить список по одному полю");
            menu.Add(numer++, "Упорядочить список по двум поям");
            menu.Add(numer++, "Отобразить уникальные имена");
            menu.Add(numer++, "Загрузить из XML");
            menu.Add(numer++, "Сохранить в XML");
            menu.Add(numer++, "Загрузить из JSON");
            menu.Add(numer++, "Сохранить в JSON");
            menu.Add(numer++, "Сгенерировать 10 сотрудников");

            do
            {
                Console.WriteLine("Программа по работе с базой сотрудников запущена. Выберите опцию:");
                MenuInConsol(menu);
                option = ExpConsol.CheckValidInput(0, menu.Count - 1);

                switch (menu[option])
                {
                    case "Закрыть программу":
                        option = 0;
                        break;

                    case "Добавить сотрудника":
                        workers.AddWorker();
                        break;

                    case "Удалить сотрудника":
                        workers.DelWorker();
                        break;

                    case "Отобразить список сотрудников":
                        workers.ListInConsole();
                        break;

                    case "Упорядочить список по одному полю":
                        workers.Sort1();   
                        break;

                    case "Упорядочить список по двум поям":
                        workers.Sort2();
                        break;

                    case "Отобразить уникальные имена":
                        workers.UnicNames();
                        break;

                    case "Загрузить из XML":
                        workers.FromXml(pathXml);
                        break;

                    case "Сохранить в XML":
                        workers.InXml(pathXml);
                        break;

                    case "Загрузить из JSON":
                        workers.FromJson(pathJson);
                        break;

                    case "Сохранить в JSON":
                        workers.InJson(pathJson);
                        break;

                    case "Сгенерировать 10 сотрудников":
                        workers.AddRandomWorkers();    
                        break;
                }

            } while (option != 0);

        }
    }
}
