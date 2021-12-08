namespace Lesson_11.Classes
{
    internal class Intern : Executor
    {
        #region Конструктор

        /// <summary>
        /// Руководитель подразделения.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="parent">Подразделение.</param>
        public Intern(string name, Department parent) : base(name, "Интерн", 500) { }

        #endregion
    }
}
