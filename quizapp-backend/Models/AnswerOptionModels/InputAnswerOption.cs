namespace quizapp_backend.Models.AnswerOptionModels
{
    public class InputAnswerOption
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}
