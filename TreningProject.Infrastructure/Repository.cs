using Microsoft.EntityFrameworkCore;
using TreningProject.Abstractions;

namespace TreningProject.Infrastructure
{
    /// <summary>
    /// Обобщенный репозиторий
    /// </summary>
    /// <typeparam name="TContext">Тип контекста данных</typeparam>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        private TContext _db;

        /// <summary>
        /// 
        /// </summary>
        private DbSet<TEntity> _entitySet;

        /// <summary>
        /// Обобщенный репозиторий
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        public Repository(TContext db)
        {
            _db = db;
            _entitySet = _db.Set<TEntity>();
        }

        /// <summary>
        /// Добавить несколько сущностей (асинхронно)
        /// </summary>
        /// <param name="entities">Сущности</param>
        /// <returns></returns>
        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            _entitySet.AddRange(entities);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получить все сущности (асинхронно)
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _entitySet.ToListAsync();
    }
}
