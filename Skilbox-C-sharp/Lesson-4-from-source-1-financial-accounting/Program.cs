// Задание 1.

// Заказчик просит вас написать приложение по учёту финансов
// и продемонстрировать его работу.
// Суть задачи в следующем: 
// Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
// За год получены два массива – расходов и поступлений.
// Определить прибыли по месяцам
// Количество месяцев с положительной прибылью.
// Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
// если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
// Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

// Пример

// Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
//     1              100 000             80 000                 20 000
//     2              120 000             90 000                 30 000
//     3               80 000             70 000                 10 000
//     4               70 000             70 000                      0
//     5              100 000             80 000                 20 000
//     6              200 000            120 000                 80 000
//     7              130 000            140 000                -10 000
//     8              150 000             65 000                 85 000
//     9              190 000             90 000                100 000
//    10              110 000             70 000                 40 000
//    11              150 000            120 000                 30 000
//    12              100 000             80 000                 20 000

// Худшая прибыль в месяцах: 7, 4, 1, 5, 12
// Месяцев с положительной прибылью: 10

int[] dohod = new int[12], rashod = new int[12];
string[] mon = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
int currentLine = 1, min = 0, prf = 0;

Console.WriteLine("Программа работает только с целыми числами.");
Console.WriteLine("Привет Бухгалтер ! Давай заполним доходы и расходы за прошедший год.");
for(int i = 0; i < 11; i++)
{
    Console.WriteLine($"За месяц {mon[i]}");
    Console.WriteLine("Доход, тыс.руб. =");
    dohod[i] = int.Parse(Console.ReadLine());
    Console.WriteLine("Расход, тыс. руб. =");
    rashod[i] = int.Parse(Console.ReadLine());
}

Console.Clear();
Console.WriteLine("Сводная таблица за год.");
Console.Write("Месяц");
Console.SetCursorPosition(Console.WindowWidth / 4,currentLine);
Console.Write("Доход, тыс. руб.");
Console.SetCursorPosition(Console.WindowWidth / 2, currentLine);
Console.Write("Расход, тыс. руб.");
Console.SetCursorPosition(Console.WindowWidth / 4 * 3, currentLine);
Console.Write("Прибыль, тыс. руб.\n");
currentLine++;
for (int i = 0; i < 11; i++)
{
    Console.Write(mon[i]);
    Console.SetCursorPosition(Console.WindowWidth / 4, currentLine);
    Console.Write(dohod[i]);
    Console.SetCursorPosition(Console.WindowWidth / 2, currentLine);
    Console.Write(rashod[i]);
    Console.SetCursorPosition(Console.WindowWidth / 4 * 3, currentLine);
    Console.Write($"{dohod[i] - rashod[i]}\n");
    currentLine++;

    if (i == 0) min = (dohod[i] - rashod[i]);
    else if (min > (dohod[i] - rashod[i])) min = (dohod[i] - rashod[i]);
    if ((dohod[i] - rashod[i]) > 0) prf++;
}

if (min != 0)
{
    Console.WriteLine("Месяцы с худшим доходом:");
    for (int i = 0; i < 11; i++) if ((dohod[dohod[i] - rashod[i]]) == min) Console.Write($" {mon[i]}");
}

Console.WriteLine($"\nКоличество месяцев с положительной прибылью = {prf}");

Console.ReadLine();