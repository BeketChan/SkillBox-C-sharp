﻿// Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

// Требуемый опыт работы: без опыта
// Частичная занятость, удалённая работа
//
// Описание 
//
// Стартап «Micarosppoftle» занимающийся разработкой
// многопользовательских игр ищет разработчиков в свою команду.
// Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
// но желающих развиваться в сфере разработки игр на платформе .NET.
//
// Должность Интерн C#/
//
// Основные требования:
// C#, операторы ввода и вывода данных, управляющие конструкции 
// 
// Конкурентным преимуществом будет знание процедурного программирования.
//
// Не технические требования: 
// английский на уровне понимания документации и справочных материалов
//
// В качестве тестового задания предлагается решить следующую задачу.
//
// Написать игру, в которою могут играть два игрока.
// При старте, игрокам предлагается ввести свои никнеймы.
// Никнеймы хранятся до конца игры.
// Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
// Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
// Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
// введенное число вычитается из gameNumber
// Новое значение gameNumber показывается игрокам на экране.
// Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
// Игра поздравляет победителя, предлагая сыграть реванш
// 
// * Бонус:
// Подумать над возможностью реализации разных уровней сложности.
// В качестве уровней сложности может выступать настраиваемое, в начале игры,
// значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

// *** Сложный бонус
// Подумать над возможностью реализации однопользовательской игры
// т е игрок должен играть с компьютером


// Демонстрация
// Число: 12,
// Ход User1: 3
//
// Число: 9
// Ход User2: 4
//
// Число: 5
// Ход User1: 2
//
// Число: 3
// Ход User2: 3
//
// User2 победил!

int mode,startNumber, levelGame, gamerMove = 0;
string gamer1, gamer2, levelText, currentGamer = "text";
Random rand = new Random();
/// <summary>
/// Для реализации большего количество игроков по хорошему нужен массив, а мы как бы их ещё не проходили ))
/// Плодить через переменные мне лень ))
/// Потому в качестве усложнения выбрал разные уровни сложности и игру против ПК.
/// Поэтому остоновимся на двух максимум.
/// </summary>
do
{
    Console.WriteLine("Так как программа без проверок вводимых данных имейте совесть и вводите только то, что требуется :)");
    Console.WriteLine("Поиграем ? Выбери режим: 1 = один игрок, 2 = два игрока, 0 = выход из игры.");
    mode = int.Parse(Console.ReadLine());

    if (mode > 0)
    {        
        Console.WriteLine("Введите имя первого игрока:");
        gamer1 = Console.ReadLine();
        if (mode == 2)
        {
            Console.WriteLine("Введите имя второго игрока:");
            gamer2 = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Вторым игроком буду я, твой компьютер !");
            gamer2 = "Твой ПК";
        }

        Console.WriteLine("Выбери сложность. 1 = простая, 2 = сложная.");
        levelGame = int.Parse(Console.ReadLine());
        if (levelGame == 1) levelText = "1, 2, 3 или 4";
        else levelText = "1, 3 или 5";

        startNumber = rand.Next(12,121);
        Console.WriteLine($"Играем от числа {startNumber}. Победит тот, после чьего ходя данное число обратиться в ноль.");

        currentGamer = gamer1;
        do
        {
            Console.WriteLine($"Число {startNumber}");
            Console.WriteLine($"Ходит {currentGamer}. Введи число из {levelText}");

            gamerMove = 0;
            switch (levelText)
            {
                case "1, 2, 3 или 4":
                    do
                    {
                        if (currentGamer != "Твой ПК")
                        {
                            gamerMove = int.Parse(Console.ReadLine());
                            if (gamerMove == 1 || gamerMove == 2 || gamerMove == 3 || gamerMove == 4) break;
                            Console.WriteLine($"Неверное число. Выбери из {levelText}");
                        }
                        else
                        {
                            gamerMove = 1;
                            if (startNumber == 2) gamerMove = 2;
                            if (startNumber == 3) gamerMove = 3;
                            if (startNumber >= 4) gamerMove = 4;
                            Console.WriteLine(gamerMove);
                            break;
                        }                        
                    } while (true);
                    break;
                case "1, 3 или 5":
                    do
                    {
                        if (currentGamer != "Твой ПК")
                        {
                            gamerMove = int.Parse(Console.ReadLine());
                            if (gamerMove == 1 || gamerMove == 3 || gamerMove == 5) break;
                            Console.WriteLine($"Неверное число. Выбери из {levelText}");
                        }
                        else
                        {
                            gamerMove = 1;
                            if (startNumber == 3) gamerMove = 3;
                            if (startNumber >= 5) gamerMove = 5;
                            Console.WriteLine(gamerMove);
                            break;
                        }
                    } while (true);
                    break;
            }

            startNumber -= gamerMove;
            if(startNumber > 0)
            {
                if (currentGamer == gamer1) currentGamer = gamer2;
                else currentGamer = gamer1;
            }
            else
            {
                Console.WriteLine($"ПОБЕДИЛ {currentGamer} !!!");
            }
        } while (startNumber > 0);

    }

} while (mode != 0);