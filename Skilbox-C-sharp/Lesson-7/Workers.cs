using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    /// <summary>
    /// Структура для работы со списком работников.
    /// </summary>
    struct Workers
    {
        #region Поля

        private Worker[] workers; // Массив работников
        private string path;      // Путь к хранимой БД.
        int index;                // Индекс для нового работника.
        string[] titles;          // Список полей БД.

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="path">Путь к хранимой БД.</param>
        public Workers(string path)
        {
            this.path = path;
            index = 0;
            titles = new string[0];
            workers = new Worker[1];

            Load();
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
            if (File.Exists(path))
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
            else
            {
                titles = "Дата создания,Дата обновления,День рождения,Фамилия,Имя,Отчество,Место рождения,Комментарий,Возраст,Рост".Split(',');
                Console.WriteLine("Файла со списком сотрудников не существует !");
            }
        }

        /// <summary>
        /// Сохранение изменений в файл.
        /// </summary>
        public void Save()
        {
            string row;
            using (StreamWriter sw = new StreamWriter(path))
            {
                row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                                        titles[0],
                                        titles[1],
                                        titles[2],
                                        titles[3],
                                        titles[4],
                                        titles[5],
                                        titles[6],
                                        titles[7],
                                        titles[8],
                                        titles[9]);
                sw.WriteLine(row);
                for (int i = 0; i < workers.Length; i++)
                {
                    row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                                        workers[0],
                                        workers[1],
                                        workers[2],
                                        workers[3],
                                        workers[4],
                                        workers[5],
                                        workers[6],
                                        workers[7],
                                        workers[8],
                                        workers[9]);
                    sw.WriteLine(row);
                }
            }
        }

        /// <summary>
        /// Вывод данных в консоль.
        /// </summary>
        public void InConsole()
        {
            if (index > 0)
            {
                Console.WriteLine("{0,10},{1,10},{2,10},{3,10},{4,10},{5,10},{6,10},{7,10},{8,10},{9,10},{10,10}",
                                        titles[0],
                                        titles[1],
                                        titles[2],
                                        titles[3],
                                        titles[4],
                                        titles[5],
                                        titles[6],
                                        titles[7],
                                        titles[8],
                                        titles[9]);
                for (int i = 0; i < workers.Length; i++)
                {
                    Console.WriteLine("{0,10},{1,10},{2,10},{3,10},{4,10},{5,10},{6,10},{7,10},{8,10},{9,10},{10,10}",
                                        workers[0],
                                        workers[1],
                                        workers[2],
                                        workers[3],
                                        workers[4],
                                        workers[5],
                                        workers[6],
                                        workers[7],
                                        workers[8],
                                        workers[9]);
                }
            }
            else Console.WriteLine("Нет данных для вывода в консоль !");
        }

        /// <summary>
        /// Количество работников.
        /// </summary>
        public int Count { get { return this.index; } }

        #endregion
    }
}
