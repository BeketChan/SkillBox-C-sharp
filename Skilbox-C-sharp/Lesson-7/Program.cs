using System;
using System.IO;

namespace Lesson_7
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
        static Worker EmployeCard()
        {
            string[] card = new string[10];
            Console.WriteLine("Заполним карточку нового сотрудника. Задачу проверки каждой запятой в текущем ДЗ не стоит. Заполняйте данные корректно.");
            card[0] = DateTime.Now.ToString();
            card[1] = DateTime.Now.ToString();
            card[2] = GetText("Дата рождения:");
            card[3] = GetText("Фамилия:");
            card[4] = GetText("Имя:");
            card[5] = GetText("Отчество:");
            card[6] = GetText("Место рождения:");
            card[7] = GetText("Комментарий:");
            card[8] = GetText("Возраст:");
            card[9] = GetText("Рост:");

            Worker wCard = new Worker(Convert.ToDateTime(card[0]),
                                      Convert.ToDateTime(card[1]),
                                      Convert.ToDateTime(card[2]),
                                      card[3],
                                      card[4],
                                      card[5],
                                      card[6],
                                      card[7],
                                      Convert.ToInt32(card[8]),
                                      Convert.ToDouble(card[9]));
            return wCard;
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
                    N = 0;
                }
                if (N >= min && N <= max) check = true;
                else Console.WriteLine("Введите корректное число !");
            } while (!check);
            return N;
        }

        static void Main(string[] args)
        {
            string path = "workers.csv";
            Workers workers = new Workers(path);

            int mode;
            do
            {
                Console.WriteLine("\nВыберите опцию:\n0 = закрыть программу\n1 = отсортировать список по дате дня рождения\n2 = выбрать из списка с датой рождения за период\n3 = добавить сотрудника\n4 = удалить сотрудника\n5 = Вывести в консоль\n");

                mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:
                        workers.SortBirthday();
                        Console.WriteLine("\nСписок работнико отсортирован по дням рождения.\n");
                        workers.InConsole();
                        break;
                    case 2:
                        workers.FiltrBirthday(DateTime.Parse(GetText("Начало периода:")), DateTime.Parse(GetText("Конец периода:")));
                        break;
                    case 3:
                        workers.AddRow(EmployeCard());
                        Console.WriteLine("Работник добавлен в список. Сохранить ? 1 = да, 2 = нет, потом.");
                        if (CheckValidInput(1, 2) == 1) workers.Save();
                        break;
                    case 4:
                        Console.WriteLine($"Укажите ID от 0 до {workers.Count}:");
                        workers.DeleteRow(CheckValidInput(0,workers.Count));
                        break;
                    case 5:
                        if (workers.Count > 0) workers.InConsole();
                        else Console.WriteLine("В базе нет рбаотников. Заведи нового.");
                        break;
                }
            } while (mode > 0);
        }
    }
}
