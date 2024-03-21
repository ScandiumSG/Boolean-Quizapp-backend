using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.ScoreModels
{
    [Table("attempt")]
    public class Attempt
    {
        [Column("user_id")]
        [ForeignKey(nameof(ApplicationUser))]
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

        //public virtual ApplicationUser User { get; set; }
        //public virtual Quiz Quiz { get; set; }
    }
}
