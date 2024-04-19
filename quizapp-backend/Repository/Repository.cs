using Microsoft.EntityFrameworkCore;
using quizapp_backend.Database;
using System.Linq.Expressions;

namespace quizapp_backend.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _db;
        private DbSet<T> _entities;

        public Repository(DatabaseContext db)
        {
            _db = db;
            _entities = db.Set<T>();
        }

        /// <inheritdoc />
        public async Task<T> Create(T entity)
        {
            _entities.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc />
        public async Task<T?> Delete(int id)
        {
            T? entity = await _entities.FindAsync(id);
            if (entity == null)
                return null;

            T? entityCopy = _db.Entry(entity).CurrentValues.Clone().ToObject() as T;

            _entities.Remove(entity);
            await _db.SaveChangesAsync();

            return entityCopy;
        }

        /// <inheritdoc />
        public async Task<ICollection<T>> Get()
        {
            return await _entities.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T?> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc />
        public async Task<T?> Update(T entity)
        {
            _entities.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
