using System;
using System.IO;

namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "workers.csv";
            Workers workers = new Workers(path);

            Console.WriteLine("Текущий список работников:");
            workers.InConsole();

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
                            
                        }
                        else Console.WriteLine("Базы по сотрудникам ещё не существует.");
                        break;
                    case 2:
                        
                        break;
                }
            } while (mode > 0);
        }
    }
}
