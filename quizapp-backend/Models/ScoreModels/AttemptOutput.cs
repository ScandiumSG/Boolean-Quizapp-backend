namespace quizapp_backend.Models.ScoreModels
{
    public class AttemptOutput
    {
        public string UserId { get; set; }

        public int QuizId { get; set; }

        public int Score { get; set; }

        public int HighestPossibleScore { get; set; }

        public int Correct { get; set; }

        public int Wrong { get; set; }
    }
}
