namespace TreningProject.Abstractions.Services
{
    /// <summary>
    /// Сервис для работы с данными о погоде
    /// </summary>
    public interface IWeatherConditionService
    {
        /// <summary>
        /// Получить данные о погоде по фильтру (асинхронно)
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <returns></returns>
        Task<IEnumerable<WeatherCondition>> GetByFilterAsync(Func<WeatherCondition, bool> filter, int skip, int take);

        /// <summary>
        /// Добавить записи о погоде (асинхронно)
        /// </summary>
        /// <param name="weathers">Коллекция записей о погоде</param>
        Task AddWeathersAsync(IEnumerable<WeatherCondition> weathers);

        /// <summary>
        /// Получить группы по фильтру
        /// </summary>
        /// <param name="groupFilter">Фильтр групп</param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetGroupKeys(Func<WeatherCondition, int> groupFilter);
    }
}
