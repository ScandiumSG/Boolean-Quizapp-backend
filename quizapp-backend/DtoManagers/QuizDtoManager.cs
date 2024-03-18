using quizapp_backend.Models.QuizModels;

namespace quizapp_backend.DtoManagers
{
    public class QuizDtoManager
    {
        public static OutputQuiz Convert(Quiz quiz)
        {
            return new OutputQuiz
            {
                Id = quiz.Id,
                UserId = quiz.UserId,
                Title = quiz.Title,
                Description = quiz.Description
            };
        }

        public static IEnumerable<OutputQuiz> Convert(IEnumerable<Quiz> quizzes)
        {
            return quizzes.Select(Convert);
        }

        public static Quiz Convert(InputQuiz inputQuiz)
        {
            return new Quiz
            {
                UserId = inputQuiz.UserId,
                Title = inputQuiz.Title,
                Description = inputQuiz.Description
            };
        }
    }
}
