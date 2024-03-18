namespace quizapp_backend.Models.QuizModels
{
    public class OutputQuiz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
