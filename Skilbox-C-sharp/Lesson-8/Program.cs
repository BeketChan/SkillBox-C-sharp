using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "hrBase.xml";
            int option;

            if (!File.Exists(path)) option = 1;
            
            do
            {
                option = 0;
            } while (option != 0);

        }
    }
}
