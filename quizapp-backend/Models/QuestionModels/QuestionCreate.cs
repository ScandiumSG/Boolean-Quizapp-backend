using quizapp_backend.Models.AnswerOptionModels;

namespace quizapp_backend.Models.QuestionModels
{
    public class QuestionCreate
    {
        public string Text { get; set; }

        public int Order { get; set; }

        public ICollection<AnswerOptionCreate> AnswerOptions { get; set; }
    }
}
