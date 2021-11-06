// Задание 2. Перестановка слов в предложении

// Что нужно сделать
// Пользователь вводит в программе длинное предложение. Каждое слово раздельно одним пробелом.
// После ввода пользователь нажимает клавишу Enter. Необходимо создать два метода:

// первый метод разделяет слова в предложении;
// второй метод меняет эти слова местами (в обратной последовательности).
using static Lesson5.TextOperators;

Console.WriteLine("Введите предложение. Слова разделяйте пробелами:");
string sentence = Console.ReadLine();
Console.WriteLine("А теперь моЩЩЩный МЕТОД переставит слова в обратном направлении !!! ВЖУХ !!");
Console.WriteLine(SentenceRevers(sentence));
Console.ReadLine();

/// <summary>
/// В /NET 6.0 изменили общую структуру программы.
/// По хорошему, разумеется, это всё в библиотеки убирать нужно. Я так понимаю.
/// Смотрел тут: https://docs.microsoft.com/ru-ru/dotnet/csharp/fundamentals/program-structure/
/// </summary>
namespace Lesson5
{
    /// <summary>
    /// Класс для манипуляций со строкой.
    /// </summary>
    public static class TextOperators
    {
        /// <summary>
        /// Разделение входящей строки на слова. Признак разделения слов = " ". Возвращает массив.
        /// </summary>
        /// <param name="Sent">Текст</param>
        /// <returns></returns>
        public static string[] SentenceSplit(string Sent)
        {
            //string[] vs = Sent.Split(' '); = для слабаков ;)
            int wordsQty = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " ") wordsQty++;
            }
            string[] words = new string[wordsQty + 1];
            int wordNum = 0;
            for (int i = 0; i < Sent.Length; i++)
            {
                if (Sent.Substring(i, 1) == " ") wordNum++;
                else words[wordNum] += Sent.Substring(i, 1);
            }
            return words;
        }

        public static string SentenceRevers(string Sent)
        {
            string[] words = SentenceSplit(Sent);
            string sentRevers = "";
            for (int i = words.Length - 1; i >= 0; i--)
                if (i == words.Length - 1) sentRevers = words[i];
                else sentRevers = sentRevers + " " + words[i];
            return sentRevers;
        }
    }
}