using quizapp_backend.Models.AnswerOptionModels;

namespace quizapp_backend.Models.QuestionModels
{
    public class QuestionPlay
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Order { get; set; }

        public virtual ICollection<AnswerOptionPlay> AnswerOptions { get; set; }
    }
}
