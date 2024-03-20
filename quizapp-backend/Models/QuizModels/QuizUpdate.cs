using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.QuizModels
{
    public class QuizUpdate
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
