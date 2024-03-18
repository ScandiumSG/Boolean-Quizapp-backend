namespace quizapp_backend.Models.QuestionUserAnswerModels
{
    public class InputUserAnswer
    {
        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public int AnswerOptionId { get; set; }
    }
}
