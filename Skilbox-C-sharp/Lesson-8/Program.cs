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
        /// Получить текст из консоли
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        static string GetText(string tittle)
        {
            Console.WriteLine(tittle);
            string text = Console.ReadLine();
            return text;
        }

        /// <summary>
        /// Получить целое число из консоли.
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        static int GetInt(string tittle)
        {
            Console.WriteLine(tittle);
            int N = -1;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное число !");
                    check = false;
                }
            } while (!check);
            return N;
        }

        /// <summary>
        /// Получить дробное число из консоли.
        /// </summary>
        /// <param name="tittle">Сообщение перед вводом текста</param>
        /// <returns></returns>
        static double GetDouble(string tittle)
        {
            Console.WriteLine(tittle);
            double N = -1;
            bool check = false;
            do
            {
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное число !");
                    check = false;
                }
            } while (!check);
            return N;
        }

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
                    N = -1;
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
        static void MenuInConsol(Dictionary<int,string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
                Console.WriteLine($"{i} = {menu[i]}");
        }

        /// <summary>
        /// Заполнение карты нового работника.
        /// </summary>
        /// <returns></returns>
        static Worker WorkerCard()
        {
            Worker worker = new Worker();
            worker.LastName = GetText("Фамилия:");
            worker.FirstName = GetText("Имя:");
            worker.Department = GetText("Подразделение:");
            worker.Position = GetText("Должность:");
            worker.Salary = GetDouble("Жалование:");
            worker.Projects = GetInt("Количество проектов:");

            return worker;
        }

        /// <summary>
        /// вывод списка работников в консоль.
        /// </summary>
        /// <param name="workers">Коллекция работников.</param>
        /// <param name="titles">Массив заголовков.</param>
        static void ListInConsole(List<Worker> workers, string[] titles)
        {
            for (int i = 0; i < titles.Length; i++)
                Console.Write($"{titles[i],15}");
            
            Console.WriteLine();
            foreach (Worker worker in workers)
            {
                Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}",
                    worker.Id,
                    worker.Department,
                    worker.LastName,
                    worker.FirstName,
                    worker.Position,
                    worker.Salary,
                    worker.Projects);
            }
        }

        /// <summary>
        /// Добавить случайных работников.
        /// </summary>
        static Worker AddRandomWorker()
        {
            string[] FirstName = { "Циклоп", "Гамбит", "Россомаха", "Зверь","Дедпул", "Саблезуб", "Магнето", "Апокалипсис","Григорий", "Константин" };
            string[] LastName = { "Иванов", "Петров", "Сидоров", "Романов","Жуков", "Рюриков", "Колыванов", "Бекетов","Корнилов", "Смит" };
            string[] Departments = { "Галера 1", "Галера 2", "Галера 3", "Руководство" };
            string[] Position = { "Быдлокодер", "Джун", "Мидл", "Лид" };
            Random rnd = new Random(Guid.NewGuid().GetHashCode()); // утянул отсюда https://stackoverflow.com/questions/39105924/how-to-randomize-seed-in-c-sharp

            Worker worker = new Worker(Departments[rnd.Next(Departments.Length)],
                                       LastName[rnd.Next(LastName.Length)],
                                       FirstName[rnd.Next(FirstName.Length)],
                                       Position[rnd.Next(Position.Length)],
                                       (rnd.Next(1000, 10001) / 10.00),
                                       rnd.Next(1, 6));
            
            return worker;
        }

        /// <summary>
        /// Сериализуем данные в Xml.
        /// </summary>
        /// <param name="workers">Коллекция с работниками.</param>
        /// <param name="path">Путь к файлу.</param>
        static void SerializeXml(List<Worker> workers, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Worker>));
            using(StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, workers);
            }
        }

        /// <summary>
        /// Десериализуем список работников из Xml.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        static List<Worker> DeserializeXml(string path)
        {
            List<Worker> tempWorkers = new List<Worker>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));
            using (StreamReader sr = new StreamReader(path))
            {
                tempWorkers = xmlSerializer.Deserialize(sr) as List<Worker>;
            }
            return tempWorkers;
        }

        /// <summary>
        /// Сериализуем данные в Json.
        /// </summary>
        /// <param name="workers">Коллекция с работниками.</param>
        /// <param name="path">Путь к файлу.</param>
        static void SerializeJson(List<Worker> workers, string path)
        {
            string json = JsonConvert.SerializeObject(workers, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Десериализуем список работников из Json.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        static List<Worker> DeserializeJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Worker>>(json);
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

            var menu = new Dictionary<int,string>();
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

            string[] titles = { "ID", "Подразделение", "Фамилия", "Имя", "Должность", "Жалование", "Проекты" };

            List<Worker> workers = new List<Worker>();

            HashSet<string> unicName = new HashSet<string>();

            List<Departments> departments = new List<Departments>();
            departments.Add(new Departments("Галера 1"));
            departments.Add(new Departments("Галера 2"));
            departments.Add(new Departments("Галера 3"));
            departments.Add(new Departments("Руководство"));

            do
            {
                Console.WriteLine("Программа по работе с базой сотрудников запущена. Выберите опцию:");
                MenuInConsol(menu);
                option = CheckValidInput(0, menu.Count - 1);

                switch (menu[option])
                {
                    case "Закрыть программу":
                        option = 0;
                        break;

                    case "Добавить сотрудника":
                        Worker tempWorker1 = WorkerCard();
                        foreach (Departments D in departments)
                            if (D.Name == tempWorker1.Department)
                            {
                                if (D.Count < D.WorkerLimit)
                                {
                                    workers.Add(WorkerCard());
                                    D.Count++;
                                }
                                else Console.WriteLine($"В подразделении {D.Name} уже максимально возможное количество работников.");
                            }                        
                        break;

                    case "Удалить сотрудника":
                        workers.Remove(new Worker() { Id = GetInt("\nВведите уникальный номер (ID):\n") });
                        break;

                    case "Отобразить список сотрудников":
                        ListInConsole(workers, titles);
                        break;

                    case "Упорядочить список по одному полю":
                        Console.WriteLine("\nСписок упорядочен по Подразделению.\n");
                        var sort1 = from Worker in workers
                                    orderby Worker.Department
                                    select Worker;
                        
                        foreach (Worker w in sort1)
                        {
                            workers.Remove(new Worker() { Id = w.Id });
                            workers.Add(w);
                        }   
                        break;

                    case "Упорядочить список по двум поям":
                        Console.WriteLine("\nСписок упорядочен по Подразделению и Жалованию.\n");
                        var sort2 = from Worker in workers
                                    orderby Worker.Department, Worker.Salary
                                    select Worker;

                        foreach (Worker w in sort2)
                        {
                            workers.Remove(new Worker() { Id = w.Id });
                            workers.Add(w);
                        }
                        break;

                    case "Отобразить уникальные имена":
                        foreach (Worker w in workers) unicName.Add(w.FirstName);
                        Console.WriteLine("\nУникальные имена:\n");
                        foreach (string i in unicName) Console.WriteLine(i);
                        Console.WriteLine();
                        break;

                    case "Загрузить из XML":
                        if (!File.Exists(pathXml)) Console.WriteLine("\nБД XML ещё не создана !\n");
                        else workers = DeserializeXml(pathXml);
                        break;

                    case "Сохранить в XML":
                        SerializeXml(workers, pathXml);
                        break;

                    case "Загрузить из JSON":
                        if (!File.Exists(pathJson)) Console.WriteLine("\nБД XML ещё не создана !\n");
                        else workers = DeserializeJson(pathJson);
                        break;

                    case "Сохранить в JSON":
                        SerializeJson(workers, pathJson);
                        break;

                    case "Сгенерировать 10 сотрудников":
                        for (int i = 0; i < 10; i++)
                        {
                            Worker tempWorker2 = AddRandomWorker();
                            foreach (Departments D in departments)
                                if (D.Name == tempWorker2.Department)
                                {
                                    if (D.Count < D.WorkerLimit)
                                    {
                                        workers.Add(tempWorker2);
                                        D.Count++;
                                    }
                                    else Console.WriteLine($"В подразделении {D.Name} уже максимально возможное количество работников.");
                                }
                        }
                            
                        break;
                }

            } while (option != 0);

        }
    }
}
