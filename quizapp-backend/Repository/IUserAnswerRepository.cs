using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;

namespace quizapp_backend.Repository
{
    public interface IUserAnswerRepository
    {
        Task<IEnumerable<UserAnswer>> Get();
        Task<UserAnswer?> Get(int questionId, int userId);
        Task<UserAnswer> Create(UserAnswer userAnswer);
        Task<UserAnswer?> Update(UserAnswer userAnswer);
        Task<UserAnswer?> Delete(int questionId, int userId);
    }
}
