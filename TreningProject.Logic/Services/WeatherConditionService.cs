using TreningProject.Abstractions.Services;
using TreningProject.Abstractions;

namespace TreningProject.Logic.Services
{
    /// <summary>
    /// Сервис для работы с данными о погоде
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class WeatherConditionService : IWeatherConditionService
    {
        /// <summary>
        /// Репозиторий
        /// </summary>
        private IRepository<WeatherCondition> _repository;

        /// <summary>
        /// Сервис для работы с данными о погоде
        /// </summary>
        /// <param name="repository">Репозиторий</param>
        public WeatherConditionService(IRepository<WeatherCondition> repository)
        {
            _repository = repository ?? throw new ArgumentNullException("");
        }

        /// <summary>
        /// Добавить записи о погоде (асинхронно)
        /// </summary>
        /// <param name="weathers">Коллекция записей о погоде</param>
        public async Task AddWeathersAsync(IEnumerable<WeatherCondition> weathers)
            => await _repository.AddAsync(weathers);

        /// <summary>
        /// Получить состояния погоды (асинхронно)
        /// </summary>
        public async Task<IEnumerable<WeatherCondition>> GetByFilterAsync(Func<WeatherCondition, bool> filter, int skip, int take)
            => (await _repository.GetAllAsync()).Where(filter)
                                                .Skip(skip)
                                                .Take(take);

        /// <summary>
        /// Получить группы по фильтру
        /// </summary>
        /// <param name="groupFilter">Фильтр групп</param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetGroupKeys(Func<WeatherCondition, int> groupFilter)
            => (await _repository.GetAllAsync()).GroupBy(groupFilter)
                                                .Select(w => w.Key)
                                                .OrderBy(w => w);
    }
}
