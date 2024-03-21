namespace quizapp_backend.Models.QuestionModels
{
    public class QuestionAttempt
    {
        public int Id { get; set; }

        public virtual ICollection<int> AnswerOptionIds { get; set; }
    }
}
