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
                UserName = quiz.User.UserName,
                Title = quiz.Title,
                Description = quiz.Description,
                Length = quiz.Questions != null ? quiz.Questions.Count() : 0
            };
        }

        public static ICollection<QuizCard> ConvertCard(ICollection<Quiz> quizzes)
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
                UserName = quiz.User.UserName,
                Title = quiz.Title,
                Description = quiz.Description,
                Questions = QuestionDtoManager.ConvertPlay(quiz.Questions)
            };
        }

        // Read Build
        public static QuizBuild ConvertBuild(Quiz quiz)
        {
            return new QuizBuild
            {
                Id = quiz.Id,
                UserId = quiz.UserId,
                UserName = quiz.User.UserName,
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

        // Read User
        public static QuizUser ConvertUser(Quiz quiz)
        {
            return new QuizUser
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
            };
        }

        public static ICollection<QuizUser> ConvertUser(ICollection<Quiz> quizzes)
        {
            return quizzes.Select(ConvertUser).ToList();
        }
    }
}
