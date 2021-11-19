using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson_8
{
    public class Company
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Company()
        {
            workers = new List<Worker>();

            unicName = new HashSet<string>();

            departments = new List<Departments>();
            departments.Add(new Departments("Галера 1"));
            departments.Add(new Departments("Галера 2"));
            departments.Add(new Departments("Галера 3"));
            departments.Add(new Departments("Руководство"));

            expConsol = new ExpansionForConsol();
        }

        #endregion

        #region Поля

        /// <summary>
        /// Список заголовков.
        /// </summary>
        private static string[] titles = { "ID", "Подразделение", "Фамилия", "Имя", "Должность", "Жалование", "Проекты" };

        /// <summary>
        /// Коллекция работников.
        /// </summary>
        private static List<Worker> workers;

        /// <summary>
        /// Коллекция уникальных имён.
        /// </summary>
        private static HashSet<string> unicName;

        /// <summary>
        /// Коллекция подразделений.
        /// </summary>
        private static List<Departments> departments;

        /// <summary>
        /// Расширенное взаимодействие с консолью.
        /// </summary>
        private static ExpansionForConsol expConsol;

        #endregion

        #region Методы

        /// <summary>
        /// Заполнение карты нового работника.
        /// </summary>
        /// <returns></returns>
        private Worker WorkerCard()
        {
            Worker worker = new Worker(expConsol.GetText("Подразделение:"),
                                       expConsol.GetText("Фамилия:"),
                                       expConsol.GetText("Имя:"),
                                       expConsol.GetText("Должность:"),
                                       expConsol.GetDouble("Жалование:"),
                                       expConsol.GetInt("Количество проектов:"));
            return worker;
        }

        /// <summary>
        /// Добавить нового работника.
        /// </summary>
        public void AddWorker()
        {
            Worker tempWorker = WorkerCard();
            foreach (Departments D in departments)
            {
                if (D.Name == tempWorker.Department)
                {
                    if (D.Count < D.WorkerLimit)
                    {
                        workers.Add(tempWorker);
                        Console.WriteLine(tempWorker.Id.ToString());
                        D.Count++;
                    }
                    else Console.WriteLine($"В подразделении {D.Name} уже максимально возможное количество работников.");
                }
            }   
        }

        /// <summary>
        /// Удаление работника.
        /// </summary>
        public void DelWorker()
        {
            workers.Remove(new Worker() { Id = expConsol.GetInt("\nВведите уникальный номер (ID):\n") });
        }

        /// <summary>
        /// вывод списка работников в консоль.
        /// </summary>
        public void ListInConsole()
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
        /// Сортировка по одному полю.
        /// </summary>
        public void Sort1()
        {
            Console.WriteLine("\nСписок упорядочен по Подразделению.\n");
            var sort1 = from Worker in workers
                        orderby Worker.Department
                        select Worker;

            foreach (Worker w in sort1)
            {
                workers.Remove(new Worker() { Id = w.Id });
                workers.Add(w);
            }
        }

        /// <summary>
        /// Сортировка по двум полям.
        /// </summary>
        public void Sort2()
        {
            Console.WriteLine("\nСписок упорядочен по Подразделению и Жалованию.\n");
            var sort2 = from Worker in workers
                        orderby Worker.Department, Worker.Salary
                        select Worker;

            foreach (Worker w in sort2)
            {
                workers.Remove(new Worker() { Id = w.Id });
                workers.Add(w);
            }
        }

        /// <summary>
        /// Вывести в консоль уникальные имена.
        /// </summary>
        public void UnicNames()
        {
            foreach (Worker w in workers) unicName.Add(w.FirstName);
            Console.WriteLine("\nУникальные имена:\n");
            foreach (string i in unicName) Console.WriteLine(i);
            Console.WriteLine();
        }

        /// <summary>
        /// Десериализуем список работников из Xml.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        private List<Worker> DeserializeXml(string path)
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
        /// Загрузить из XML.
        /// </summary>
        /// <param name="path">Имя файла.</param>
        public void FromXml(string path)
        {
            if (!File.Exists(path)) Console.WriteLine("\nБД XML ещё не создана !\n");
            else workers = DeserializeXml(path);
        }

        /// <summary>
        /// Сериализуем данные в Xml.
        /// </summary>
        /// <param name="workers">Коллекция с работниками.</param>
        /// <param name="path">Путь к файлу.</param>
        private void SerializeXml(List<Worker> workers, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Worker>));
            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, workers);
            }
        }

        /// <summary>
        /// Сохранить в XML.
        /// </summary>
        /// <param name="path">Имя файла.</param>
        public void InXml(string path)
        {
            SerializeXml(workers, path);
        }

        /// <summary>
        /// Десериализуем список работников из Json.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        private List<Worker> DeserializeJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Worker>>(json);
        }

        /// <summary>
        /// Загрузить из JSON.
        /// </summary>
        /// <param name="path">Имя файла.</param>
        public void FromJson(string path)
        {
            if (!File.Exists(path)) Console.WriteLine("\nБД XML ещё не создана !\n");
            else workers = DeserializeJson(path);
        }

        /// <summary>
        /// Сериализуем данные в Json.
        /// </summary>
        /// <param name="workers">Коллекция с работниками.</param>
        /// <param name="path">Путь к файлу.</param>
        private void SerializeJson(List<Worker> workers, string path)
        {
            string json = JsonConvert.SerializeObject(workers, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Сохранить в JSON.
        /// </summary>
        /// <param name="path">Имя файла.</param>
        public void InJson(string path)
        {
            SerializeJson(workers, path);
        }

        /// <summary>
        /// Добавить случайных работников.
        /// </summary>
        private Worker AddRandomWorker()
        {
            string[] FirstName = { "Циклоп", "Гамбит", "Россомаха", "Зверь", "Дедпул", "Саблезуб", "Магнето", "Апокалипсис", "Григорий", "Константин" };
            string[] LastName = { "Иванов", "Петров", "Сидоров", "Романов", "Жуков", "Рюриков", "Колыванов", "Бекетов", "Корнилов", "Смит" };
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
        /// Сгенерировать 10 работников.
        /// </summary>
        public void AddRandomWorkers()
        {
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
        }

        #endregion
    }
}
