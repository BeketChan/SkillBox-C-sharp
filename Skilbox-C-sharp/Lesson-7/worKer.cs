using System;

namespace lesson_7
{
    
    internal class Worker
    {
        #region Свойства
        
        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime AddDate { get; set; }
        
        /// <summary>
        /// дата последнего редактирования записи.
        /// </summary>
        public DateTime UpdateDate { get; set; }
        
        /// <summary>
        /// День рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }
        
        /// <summary>
        /// Место рождения.
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Карточка работника.
        /// </summary>
        /// <param name="Id">ID записи.</param>
        /// <param name="AddDate">Дата создания записи.</param>
        /// <param name="UpdateDate">Дата обновления записи.</param>
        /// <param name="Birthday">День рождения</param>
        /// <param name="LastName">Фамилия.</param>
        /// <param name="FirstName">Имя.</param>
        /// <param name="MiddleName">Отчество.</param>
        /// <param name="BirthPlace">Место рождения.</param>
        /// <param name="Comment">Комментарий.</param>
        /// <param name="Age">Возраст.</param>
        /// <param name="Height">Рост.</param>
        public Worker(DateTime AddDate,
                      DateTime UpdateDate,
                      DateTime Birthday,
                      string LastName,
                      string FirstName,
                      string MiddleName,
                      string BirthPlace,
                      string Comment,
                      int Age,
                      double Height)
        {
            this.AddDate = AddDate;
            this.UpdateDate = UpdateDate;
            this.Birthday = Birthday;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.BirthPlace = BirthPlace;
            this.Comment = Comment;
            this.Age = Age;
            this.Height = Height;
        }

        /// <summary>
        /// Краткая карточка работника.
        /// </summary>
        /// <param name="LastName"></param>
        /// <param name="FirstName"></param>
        /// <param name="MiddleName"></param>
        public Worker(string LastName,
                      string FirstName,
                      string MiddleName) :
            this(DateTime.Now, DateTime.Now, DateTime.Now, LastName, FirstName, MiddleName, string.Empty, "Неполные данные. Отобрать паспорт и заполнить в течении трёх дней.", 0, 0)
        { }

        #endregion
    }
}
