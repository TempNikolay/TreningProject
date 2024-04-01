namespace TreningProject.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Получить все сущности (асинхронно)
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Добавить несколько сущностей (асинхронно)
        /// </summary>
        /// <param name="entities">Сущности</param>
        /// <returns></returns>
        Task AddAsync(IEnumerable<TEntity> entities);
    }
}
