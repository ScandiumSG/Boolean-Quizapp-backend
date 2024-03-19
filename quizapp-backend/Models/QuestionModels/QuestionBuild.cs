using quizapp_backend.Models.AnswerOptionModels;

namespace quizapp_backend.Models.QuestionModels
{
    public class QuestionBuild
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Order { get; set; }

        public virtual ICollection<AnswerOptionBuild> AnswerOptions { get; set; }
    }
}
