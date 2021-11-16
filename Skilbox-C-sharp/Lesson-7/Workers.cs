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
            titles = new string[10];
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
        public void AddRow(Worker newWorker)
        {
            Resize(index >= workers.Length);
            workers[index] = newWorker;
            index++;
        }

        /// <summary>
        /// Удаление работника из списка.
        /// </summary>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="middleName">Отчество.</param>
        public void DeleteRow(int delIndex)
        {
            if ((workers[delIndex] != null))
                workers[delIndex] = null;
            
        }

        /// <summary>
        /// Фильтрация сотрудников по дате дня рождения.
        /// </summary>
        /// <param name="date1">Начало периода.</param>
        /// <param name="date2">Конец периода.</param>
        public void FiltrBirthday(DateTime date1, DateTime date2)
        {
            for(int i=0; i<index; i++)
            {
                if ((workers[i] != null) && !((workers[i].Birthday >= date1) && (workers[i].Birthday <= date2)))
                    workers[i] = null;
            }
            Console.WriteLine("Записи вне фильтра удалены из списка.");
            InConsole();
        }

        /// <summary>
        /// Сортировка по дню рождения.
        /// </summary>
        public void SortBirthday()
        {
            // подсмотрел тут https://social.msdn.microsoft.com/Forums/ru-RU/2d1efa85-11cc-4a28-8264-e72822bcc47f/1057108610881090108010881086107410821072?forum=programminglanguageru
            Array.Sort(workers, new Comparison<Worker>((a, b) => a.Birthday.CompareTo(b.Birthday)));
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
                    try
                    {
                        titles = sr.ReadLine().Split('#');
                        while (!sr.EndOfStream)
                        {
                            string[] row = sr.ReadLine().Split('#');
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
                    catch
                    {
                        titles = "Дата создания,Дата обновления,День рождения,Фамилия,Имя,Отчество,Место рождения,Комментарий,Возраст,Рост".Split(',');
                    }
                }
            }
            else
            {
                titles = "Дата создания,Дата обновления,День рождения,Фамилия,Имя,Отчество,Место рождения,Комментарий,Возраст,Рост".Split(',');
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
                row = string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}",
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
                for (int i = 0; i < index; i++)
                {
                    if (workers[i] != null)
                    {
                        row = string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}",
                                        workers[i].AddDate,
                                        workers[i].UpdateDate,
                                        workers[i].Birthday,
                                        workers[i].LastName,
                                        workers[i].FirstName,
                                        workers[i].MiddleName,
                                        workers[i].BirthPlace,
                                        workers[i].Comment,
                                        workers[i].Age,
                                        workers[i].Height);
                        sw.WriteLine(row);
                    }   
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
                Console.WriteLine("{0,5}{1,20}{2,20}{3,20}{4,10}{5,10}{6,10}{7,10}{8,10}{9,10}{10,10}",
                                        "ID",
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
                for (int i = 0; i < index; i++)
                {
                    if (workers[i] != null)
                        Console.WriteLine("{0,5}{1,20:d}{2,20:d}{3,20:d}{4,10}{5,10}{6,10}{7,10}{8,10}{9,10}{10,10}",
                                            i,
                                            workers[i].AddDate,
                                            workers[i].UpdateDate,
                                            workers[i].Birthday,
                                            workers[i].LastName,
                                            workers[i].FirstName,
                                            workers[i].MiddleName,
                                            workers[i].BirthPlace,
                                            workers[i].Comment,
                                            workers[i].Age,
                                            workers[i].Height);
                }
            }
            else Console.WriteLine("Нет данных для вывода в консоль !");
        }

        /// <summary>
        /// Количество работников.
        /// </summary>
        public int Count { get { return index; } }

        #endregion
    }
}
