using System;
using System.IO;

namespace Lesson_6_from_site_1_emp_data_base
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
        /// Заполняем карточку клиента
        /// </summary>
        /// <returns></returns>
        static string[] EmployeCard()
        {
            string[] card = new string[7];
            Console.WriteLine("Заполним карточку нового сотрудника.");
            card[0] = GetText("Фамилия:");
            card[1] = GetText("Имя:");
            card[2] = GetText("Отчество:");
            card[3] = GetText("Возраст:");
            card[4] = GetText("Рост:");
            card[5] = GetText("Дата рождения:");
            card[6] = GetText("Место рождения:");
            return card;
        }

        /// <summary>
        /// Считываем строки БД для дальнейших манипуляций.
        /// </summary>
        /// <param name="path">Путь к БД</param>
        /// <returns></returns>
        static string[] GetDB(string path)
        {
            int rowQty = 0;
            string s;
            using (StreamReader sr = new StreamReader(path))
                while ((s = sr.ReadLine()) != null) rowQty++;
            string[] lines = new string[rowQty];
            rowQty = 0;
            using (StreamReader sr = new StreamReader(path))
                while (!sr.EndOfStream)
                    lines[rowQty++] = sr.ReadLine();
            return lines;
        }

        /// <summary>
        /// Добавление строки в БД
        /// </summary>
        /// <param name="path">Путь к БД.</param>
        /// <param name="currentRows">Текущее количество записей.</param>
        /// <param name="row">Массив с добавляемыми данными.</param>
        static void AddInDB(string path, int currentRows, string[] row)
        {
            string newRecord = $"{++currentRows}#{DateTime.Now.ToString("dd.MM.yyyy")} {DateTime.Now.ToString("hh:mm")}#{row[0]} {row[1]} {row[2]}#{row[3]}#{row[4]}#{row[5]}#{row[6]}";
            using (StreamWriter sr = File.AppendText(path)) sr.WriteLine(newRecord);
        }

        /// <summary>
        /// Вывод на экран текущей БД.
        /// </summary>
        /// <param name="enpBD">Массив со строками БД.</param>
        static void PrintDB(string[] empBD)
        {
            string[] line = new string[7];
            for(int i = 0; i < empBD.Length; i++)
            {
                line = empBD[i].Split('#');
                Console.WriteLine($"Сотрудник: {line[2]}, возраст: {line[3]}, рост: {line[4]}, дата рождения: {line[5]}, место рождения: город {line[6]}");
            }
        }

        static void Main(string[] args)
        {
            string path = "empDB.csv";
            string[] empDB;
            int mode;
            do
            {
                Console.WriteLine("В задании нет требования проверки вводимых данных, поэтому я исхожу из того, что всё (включая формат дат) заполняется корректно.");
                Console.WriteLine("Выберите опцию: 0 = закрыть программу, 1 = вывести список сотрудников на экран, 2 = добавить сотрудника");
                mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:
                        if (File.Exists(path))
                        {
                            empDB = GetDB(path);
                            PrintDB(empDB);
                        }
                        else Console.WriteLine("Базы по сотрудникам ещё не существует.");
                        break;
                    case 2:
                        string[] empCard = EmployeCard();
                        if (!File.Exists(path)) using (StreamWriter sw = File.CreateText(path)) ;
                        empDB = GetDB(path);
                        AddInDB(path,empDB.Length,empCard);
                        break;
                }
            } while (mode > 0);
        }
    }
}
