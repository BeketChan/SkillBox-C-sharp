/// <summary>
/// 
/// Домашнее задание 2.
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
name1 = "Ivan";
name2 = "Petr";
name3 = "Liza";

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
/// Я решил отцетровывать только по шири не консоли. В принципе можно и по высоте, но так можно "наползти" на предыдущий ввод текста.
/// </summary>
int currentTop = 5;
Console.SetCursorPosition((Console.WindowWidth - "Бонусная часть".Length) / 2, currentTop);
Console.WriteLine("Бонусная часть");
currentTop++;

string pattern1 = "Имя: {0} Возраст: {1} Рост: {2} История: {3} Математика: {4} Русский язык: {5} Средний бал: {6:#.##}";
Console.SetCursorPosition((Console.WindowWidth - pattern1.Length) / 2, currentTop);
Console.WriteLine(pattern1, name1, age1, height1, hist1, math1, rus1, average1);
currentTop++;
Console.SetCursorPosition((Console.WindowWidth - pattern1.Length) / 2, currentTop);
Console.WriteLine(pattern1, name2, age2, height2, hist2, math2, rus2, average2);
currentTop++;
Console.SetCursorPosition((Console.WindowWidth - pattern1.Length) / 2, currentTop);
Console.WriteLine(pattern1, name3, age3, height3, hist3, math3, rus3, average3);

Console.ReadKey();