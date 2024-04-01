using TreningProject.Abstractions;

namespace TreningProject.ViewModel
{
    /// <summary>
    /// Модель разбивки на страницы
    /// </summary>
    public class PaginationModel
    {
        /// <summary>
        /// Группирование
        /// </summary>
        public Grouping Grouping { get; set; }
        
        /// <summary>
        /// Страницы
        /// </summary>
        public IEnumerable<int> Pages { get; set; }

        /// <summary>
        /// Текущая страница
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Погодные условия
        /// </summary>
        public IEnumerable<WeatherCondition> WeatherConditions { get;set; }
    }
}
