using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.QuizModels
{
    public class QuizCreate
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<QuestionCreate> Questions { get; set; }
    }
}
