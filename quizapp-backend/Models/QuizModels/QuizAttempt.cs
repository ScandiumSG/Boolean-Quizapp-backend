using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.QuizModels
{
    public class QuizAttempt
    {
        public string UserId { get; set; }

        public ICollection<QuestionAttempt> Questions { get; set; }
    }
}
