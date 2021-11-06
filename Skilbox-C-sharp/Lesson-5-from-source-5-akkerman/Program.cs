using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// *Задание 5
// Вычислить, используя рекурсию, функцию Аккермана:
// A(2, 5), A(1, 2)
// A(n, m) = m + 1, если n = 0,
//         = A(n - 1, 1), если n <> 0, m = 0,
//         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.

namespace Lesson_5_from_source_5_akkerman
{
    internal class Program
    {
        /// <summary>
        /// Функйия Аккермана.
        /// </summary>
        /// <param name="n">Первый параметр.</param>
        /// <param name="m">Второй парамтер.</param>
        /// <returns></returns>
        static int A(int n, int m)
        {
            if (n == 0) return m + 1;
            if (n != 0 & m == 0) return A(n - 1, 1);
            if (n > 0 & m > 0) return A(n - 1, A(n, m - 1));
            return A(n, m);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(A(n, m));
            
            Console.ReadKey();
        }        
    }
}
