using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuizModels;

namespace quizapp_backend.Services.DtoManagers
{
    public class QuizDtoManager
    {
        public static QuizCard ConvertCard(Quiz quiz)
        {
            return new QuizCard
            {
                Id = quiz.Id,
                UserId = quiz.UserId,
                Title = quiz.Title,
                Description = quiz.Description,
                Length = quiz.Questions != null ? quiz.Questions.Count() : 0
            };
        }

        public static ICollection<QuizCard> Convert(ICollection<Quiz> quizzes)
        {
            return quizzes.Select(ConvertCard).ToList();
        }


        // Read Play
        public static QuizPlay ConvertPlay(Quiz quiz)
        {
            return new QuizPlay
            {
                Id = quiz.Id,
                UserId = quiz.UserId,
                Title = quiz.Title,
                Description = quiz.Description,
                Questions = QuestionDtoManager.ConvertPlay(quiz.Questions)
            };
        }

        public static QuizBuild ConvertBuild(Quiz quiz)
        {
            return new QuizBuild
            {
                Id = quiz.Id,
                UserId = quiz.UserId,
                Title = quiz.Title,
                Description = quiz.Description,
                Questions = quiz.Questions != null ? QuestionDtoManager.ConvertBuild(quiz.Questions) : new List<QuestionBuild>()
            };
        }

        // Create
        public static Quiz Convert(QuizCreate inputQuiz)
        {
            return new Quiz
            {
                UserId = inputQuiz.UserId,
                Title = inputQuiz.Title,
                Description = inputQuiz.Description,
                Questions = QuestionDtoManager.Convert(inputQuiz.Questions)
            };
        }
    }
}
