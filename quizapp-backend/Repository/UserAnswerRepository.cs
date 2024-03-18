using Microsoft.EntityFrameworkCore;
using quizapp_backend.Database;
using quizapp_backend.Models.QuestionUserAnswerModels;

namespace quizapp_backend.Repository
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private DatabaseContext _db;
        private DbSet<UserAnswer> _entities;

        public UserAnswerRepository(DatabaseContext db)
        {
            _db = db;
            _entities = db.Set<UserAnswer>();
        }

        public async Task<UserAnswer> Create(UserAnswer entity)
        {
            _entities.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<UserAnswer?> Delete(int questionId, int userId)
        {
            var entity = await _entities.FindAsync(questionId, userId);
            if (entity == null)
                return null;

            var entityCopy = _db.Entry(entity).CurrentValues.Clone().ToObject() as UserAnswer;

            _entities.Remove(entity);
            await _db.SaveChangesAsync();

            return entityCopy;
        }

        public async Task<IEnumerable<UserAnswer>> Get()
        {
            return await _entities.ToListAsync();
        }

        public async Task<UserAnswer?> Get(int questionId, int userId)
        {
            return await _entities.FindAsync(questionId, userId);
        }

        public async Task<UserAnswer?> Update(UserAnswer entity)
        {
            _entities.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
