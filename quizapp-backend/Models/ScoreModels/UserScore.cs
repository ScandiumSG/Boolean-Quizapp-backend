using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.ScoreModels
{
    [Table("user_scores")]
    public class UserScore
    {
        [Column("user_id")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column("quiz_id")]
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("highest_possible_score")]
        public int HighestPossibleScore { get; set; }

        [Column("correct")]
        public int Correct { get; set; }

        [Column("wrong")]
        public int Wrong { get; set; }
    }
}
