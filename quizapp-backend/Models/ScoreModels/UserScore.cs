namespace quizapp_backend.Models.ScoreModels
{
    public class UserScore
    {
        public string UserId { get; set; }
        public int Score { get; set; }
        public int HighestPossibleScore { get; set; }
        public int correct { get; set; }
    }
}
