using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.QuestionUserAnswerModels
{
    [Table("user_answers")]
    public class UserAnswer
    {
        [Column("id")]
        public int QuestionId { get; set; }

        [Column("user_id")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column("answer_option_id")]
        [ForeignKey("AnswerOption")]
        public int AnswerOptionId { get; set; }

        public virtual AnswerOption AnswerOption { get; set; }
        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
