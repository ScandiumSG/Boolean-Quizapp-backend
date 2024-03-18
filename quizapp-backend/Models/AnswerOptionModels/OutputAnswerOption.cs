using quizapp_backend.Models.QuestionModels;

namespace quizapp_backend.Models.AnswerOptionModels
{
    public class OutputAnswerOption
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}
