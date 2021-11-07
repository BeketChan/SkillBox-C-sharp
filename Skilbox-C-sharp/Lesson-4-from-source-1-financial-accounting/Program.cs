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

int[] dohod = new int[12], rashod = new int[12], profit = new int[12];
string[] mon = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
int[] worstProfit = new int[3];
int prf = 0;
Random rand = new Random();

Console.WriteLine("Программа работает только с целыми числами.");
for(int i = 0; i < 12; i++)
{
    dohod[i] = rand.Next(10, 11);
    rashod[i] = rand.Next(10, 11);
}

Console.Clear();
Console.WriteLine("Сводная таблица за год.");
Console.WriteLine("Месяц             Доход, тыс. руб.    Расход, тыс. руб.   Прибыль, тыс. руб.");
for (int i = 0; i < 12; i++)
{
    profit[i] = dohod[i] - rashod[i];
    Console.WriteLine($"{mon[i],10}{dohod[i],20:0,0}{rashod[i],20:0,0}{profit[i],20:0,0}");    
    if ((dohod[i] - rashod[i]) > 0) prf++;
}

Array.Sort(profit);
int numer = 0;
for (int i = 0; numer < worstProfit.Length & i < profit.Length; i++)
{
    if (i == 0) worstProfit[numer++] = profit[i];
    else if (worstProfit[numer - 1] == profit[i]) continue;
    else worstProfit[numer++] = profit[i];
}

Console.WriteLine("\nМесяца с тремя наихудшими показателями :");

for (int j = 0; j < worstProfit.Length; j++)
{
    if (j > 0 && worstProfit[j] == worstProfit[j - 1]) continue;
    else
    {
        for (int k = 0; k < profit.Length; k++)
        {
            if (dohod[k] - rashod[k] == worstProfit[j]) Console.Write($"{mon[k]} ");
        }
        Console.Write($" = {worstProfit[j]}\n");
    }
}
Console.WriteLine($"\nКоличество месяцев с положительной прибылью = {prf}");
Console.ReadLine();