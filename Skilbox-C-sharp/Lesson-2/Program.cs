/// <summary>
/// 
/// Домашнее задание 2.
/// Текст задания взял из "2.1_Исходники". Есть небольшие различия: например, на сайте требуют создать переменную под сумму баллов, в исходниках нет.
/// 
/// </summary>

// See https://aka.ms/new-console-template for more information

// Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

// В данной программе, должна быть возможность изменения значений нескольких переменных для того,
// чтобы персонифецировать вывод данных, под конкретного пользователя.

// Для этого нужно: 
// 1. Создать несколько переменных разных типов, в которых могут храниться данные
//    - имя;
string name1, name2, name3;
name1 = "Ivan Ivanovich Ivanov";
name2 = "Petr Petrovich Petrov";
name3 = "Liza Petrovna Ivanova";

//    - возраст;
byte age1, age2, age3;
age1 = 23;
age2 = 22;
age3 = 20;

//    - рост;
double height1, height2, height3;
height1 = 182.2;
height2 = 178.5;
height3 = 155.1;

//    - баллы по трем предметам: история, математика, русский язык;
/// <summary>
/// По заданию эти переменные должны быть числами с плавающей точкой, но я нигде не припомю выдачу дробных баллов :)
/// </summary>
byte hist1, hist2, hist3;
hist1 = 4;
hist2 = 5;
hist3 = 3;
byte math1, math2, math3;
math1 = 4;
math2 = 3;
math3 = 2;
byte rus1, rus2, rus3;
rus1 = 2;
rus2 = 3;
rus3 = 4;

// 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
//    указанным в пункте 1.
double average1, average2, average3;
average1 = (double)(hist1 + math1 + rus1) / 3;
average2 = (double)(hist2 + math2 + rus2) / 3;
average3 = (double)(hist3 + math3 + rus3) / 3;

// 3. Реализовать возможность печатки информации на консоли при помощи 
//    - обычного вывода;
Console.WriteLine(name1 + age1 + height1 + hist1 + math1 + rus1 + average1);
//    - форматированного вывода;
Console.WriteLine("Имя: " + name2 + " Возраст: " + age2 + " Рост: " + height2 + " История: " + hist2 + " Математика: " + math2 + " Русский язык: " + rus2 + " Средний бал: " + average2);
//    - использования интерполяции строк;
Console.WriteLine($"Имя: {name3} Возраст: {age3} Рост: {height3} История: {hist3} Математика: {math3} Русский язык: {rus3} Средний бал: {average3:#.##}");

// 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

// **
// 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
//    возможность вывода данных в центре консоли.
/// <summary>
/// Я решил отцетровывать только по ширине консоли. В принципе можно и по высоте, но так можно "наползти" на предыдущий ввод текста.
/// </summary>
int currentTop = 5;
Console.SetCursorPosition((Console.WindowWidth - "Бонусная часть".Length) / 2, currentTop);
Console.WriteLine("Бонусная часть");
currentTop++;
Console.ReadKey();

string pattern1 = "ФИО: {0} Возраст: {1} Рост: {2}";
string pattern2 = "История: {0} Математика: {1} Русский язык: {2} Средний бал: {3:#.##}";
/// <summary>
/// 9 и 17 = длина всех {} элементов в переменных "pattern".
/// Разделил вывод на две строки, так как в некоторых случаях длинна строки больше ширины окна консоли
/// </summary>
Console.SetCursorPosition((Console.WindowWidth - (pattern1.Length - 9 + name1.Length + Convert.ToString(age1).Length + Convert.ToString(height1).Length)) / 2, currentTop);
Console.WriteLine(pattern1, name1, age1, height1);
currentTop++;
Console.SetCursorPosition((Console.WindowWidth - (pattern2.Length - 17 + Convert.ToString(hist1).Length + Convert.ToString(math1).Length + Convert.ToString(rus1).Length + Convert.ToString(Math.Round((decimal)average1,2)).Length)) / 2, currentTop);
Console.WriteLine(pattern2, hist1, math1, rus1, average1);
currentTop++;
Console.ReadKey();

Console.SetCursorPosition((Console.WindowWidth - (pattern1.Length - 9 + name2.Length + Convert.ToString(age2).Length + Convert.ToString(height2).Length)) / 2, currentTop);
Console.WriteLine(pattern1, name2, age2, height2);
currentTop++;
Console.SetCursorPosition((Console.WindowWidth - (pattern2.Length - 17 + Convert.ToString(hist2).Length + Convert.ToString(math2).Length + Convert.ToString(rus2).Length + Convert.ToString(Math.Round((decimal)average2, 2)).Length)) / 2, currentTop);
Console.WriteLine(pattern2, hist2, math2, rus2, average2);
currentTop++;
Console.ReadKey();

Console.SetCursorPosition((Console.WindowWidth - (pattern1.Length - 9 + name3.Length + Convert.ToString(age3).Length + Convert.ToString(height3).Length)) / 2, currentTop);
Console.WriteLine(pattern1, name3, age3, height3);
currentTop++;
Console.SetCursorPosition((Console.WindowWidth - (pattern2.Length - 17 + Convert.ToString(hist3).Length + Convert.ToString(math3).Length + Convert.ToString(rus3).Length + Convert.ToString(Math.Round((decimal)average3, 2)).Length)) / 2, currentTop);
Console.WriteLine(pattern2, hist3, math3, rus3, average3);

Console.ReadKey();