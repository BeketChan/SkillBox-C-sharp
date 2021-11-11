using lesson_7;
using System;
using System.IO;

namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "workers.csv";
            Workers[] workers;

            int mode;
            do
            {
                Console.WriteLine("Выберите опцию: 0 = закрыть программу, 1 = вывести список сотрудников на экран, 2 = добавить сотрудника");
                mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:
                        if (File.Exists(path))
                        {
                            //empDB = GetDB(path);
                            //PrintDB(empDB);
                        }
                        else Console.WriteLine("Базы по сотрудникам ещё не существует.");
                        break;
                    case 2:
                        //string[] empCard = EmployeCard();
                        if (!File.Exists(path)) using (StreamWriter sw = File.CreateText(path)) ;
                        //empDB = GetDB(path);
                        //AddInDB(path, empDB.Length, empCard);
                        break;
                }
            } while (mode > 0);
        }
    }
}
