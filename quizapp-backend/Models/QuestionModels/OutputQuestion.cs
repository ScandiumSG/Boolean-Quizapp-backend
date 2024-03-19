namespace quizapp_backend.Models.QuestionModels
{
    public class OutputQuestion
    {
        public int Id { get; set; }

        public int QuizId { get; set; }

        public string Text { get; set; }

        public int Order { get; set; }
    }
}
