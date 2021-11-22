using System;

namespace Lesson_8
{
    public class Worker : IEquatable<Worker>
    {
        #region Свойства

        /// <summary>
        /// Уникальный номер.
        /// </summary>
        //[field: NonSerialized] // Метод был provat set. Но не желал сериализовываться. Пробовал исключить - не сработало. Не понял, почему.
        public int Id { get; set; }

        /// <summary>
        /// Отдел.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Зарплата.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Количество проектов.
        /// </summary>
        public int Projects { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Пустой конструктор карточки работника.
        /// </summary>
        public Worker() { }

        /// <summary>
        /// Карточка работника.
        /// </summary>
        /// <param name="Id">Уникальный номер</param>
        /// <param name="Department">Подразделениею</param>
        /// <param name="LastName">Фамилия.</param>
        /// <param name="FirstName">Имя.</param>
        /// <param name="Position">Должность.</param>
        /// <param name="Salary">Зарплата.</param>
        /// <param name="Projects">Количесвто проектов.</param>
        public Worker(int Id,
                      string Department,
                      string LastName,
                      string FirstName,
                      string Position,
                      double Salary,
                      int Projects)
        {
            this.Id = Id;
            this.Department = Department;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Position = Position;
            this.Salary = Salary;
            this.Projects = Projects;
        }

        /// <summary>
        /// Карточка работника.
        /// </summary>
        /// <param name="Department">Подразделениею</param>
        /// <param name="LastName">Фамилия.</param>
        /// <param name="FirstName">Имя.</param>
        /// <param name="Position">Должность.</param>
        /// <param name="Salary">Зарплата.</param>
        /// <param name="Projects">Количесвто проектов.</param>
        public Worker(string Department,
                      string LastName,
                      string FirstName,
                      string Position,
                      double Salary,
                      int Projects)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            Id = random.Next();
            this.Department = Department;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Position = Position;
            this.Salary = Salary;
            this.Projects = Projects;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Реализацию удаления элемента коллекции посмотрел тут: https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.list-1.remove?view=netframework-4.8
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Worker worker = obj as Worker;
            if (worker == null) return false;
            else return Equals(worker);
        }

        /// <summary>
        /// Сравнение текущего элемента коллекции с образцом.
        /// </summary>
        /// <param name="other">Образец.</param>
        /// <returns></returns>
        public bool Equals(Worker other)
        {
            if (other == null) return false;
            return (Id.Equals(other.Id));
        }

        #endregion
    }
}