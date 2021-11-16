using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson_8
{
    internal class Program
    {
        /// <summary>
        /// Проверка корректности ввода целых чисел в указанный диапазон с возвратом прошедшего проверку значения.
        /// </summary>
        /// <param name="min">От</param>
        /// <param name="max">До</param>
        /// <returns></returns>
        static int CheckValidInput(int min, int max)
        {
            int N;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    N = 0;
                }
                if (N >= min && N <= max) check = true;
                else Console.WriteLine("Введите корректное число !");
            } while (!check);
            return N;
        }

        /// <summary>
        /// Вывод опций меню в консоль.
        /// </summary>
        /// <param name="menu">Массив с пунктами меню.</param>
        static void MenuInConsol(string[] menu)
        {
            for(int i=0; i<menu.Length; i++)
                Console.WriteLine($"{i} = {menu[i]}");
        }

        static Worker DeserializeDepXml(string path)
        {
            Worker tempWorker = new Worker();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    tempWorker = xmlSerializer.Deserialize(sr) as Worker;
                }
            }
            return tempWorker;
        }
        static void Main(string[] args)
        {
            string pathXml = "hrBase.xml", pathJson = "hrBase.json";
            int option = 1;
            string[] menu = { "Закрыть программу",
                              "Добавить сотрудника",
                              "Удалить сотрудника",
                              "Отобразить список сотрудников",
                              "Упорядочить список по одному полю",
                              "Упорядочить список по двум поям",
                              "Отфильтровать по Отделу",
                              "Отобразить уникальные зарплаты",
                              "Загрузить из XML",
                              "Сохранить в XML",
                              "Загрузить из JSON",
                              "Сохранить в JSON" };
            List<Worker> depList = new List<Worker>();
            
            do
            {
                Console.WriteLine("Программа по работе с базой сотрудников запущена. Выберите опцию:");
                MenuInConsol(menu);
                option = CheckValidInput(0, menu.Length);

                switch (menu[option])
                {
                    case "Закрыть программу":
                        option = 0;
                        break;
                    case "Загрузить из XML":
                        if (!File.Exists(pathXml)) Console.WriteLine("БД XML ещё не создана !");
                        //else 
                        break;
                }

            } while (option != 0);

        }
    }
}
