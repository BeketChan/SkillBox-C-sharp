using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7
{
    internal struct Workers
    {
        #region Поля

        private Worker[] workers; // Массив работников
        private string path;      // Путь к хранимой БД.
        int index;                // Индекс для нового работника.
        string[] titles;          // Список полей БД.

        #endregion

        #region Конструкторы

        /// <summary>
        /// Массив работников.
        /// </summary>
        /// <param name="path">Путь к хранимой БД.</param>
        public Workers(string path)
        {
            this.path = path;
            index = 0;
            titles = new string[0];
            workers = new Worker[1];
        }

        #endregion

        #region Методы

        /// <summary>
        /// Увеличние размера массива работников.
        /// </summary>
        /// <param name="flag">Признак необхадимости увеличения.</param>
        private void Resize(bool flag)
        {
            if(flag)
                Array.Resize(ref workers, 5);
        }

        /// <summary>
        /// Добавление нового работника.
        /// </summary>
        /// <param name="newWorker">Новый работник.</param>
        private void AddRow(Worker newWorker)
        {
            Resize(index >= workers.Length);
            workers[index] = newWorker;
            index++;
        }

        /// <summary>
        /// Загрузка данных из файла.
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                titles = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    string[] row = sr.ReadLine().Split(',');
                    AddRow(new Worker(Convert.ToDateTime(row[0]),
                                      Convert.ToDateTime(row[1]),
                                      Convert.ToDateTime(row[2]),
                                      row[3],
                                      row[4],
                                      row[5],
                                      row[6],
                                      row[7],
                                      Convert.ToInt32(row[8]),
                                      Convert.ToDouble(row[9])));
                    
                }
            }
        }




        #endregion
    }
}
