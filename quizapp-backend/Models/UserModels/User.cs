using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.UserModels
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public virtual List<Quiz> Quizzes { get; set; }
        public virtual List<UserAnswer> QuestionUserAnswers { get; set; }
    }
}
