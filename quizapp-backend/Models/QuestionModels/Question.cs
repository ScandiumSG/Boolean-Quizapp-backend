using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.QuestionModels
{
    [Table("questions")]
    public class Question
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("quiz_id")]
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        [Column("text")]
        public string Text { get; set; }


        public virtual Quiz Quiz { get; set; }
        public virtual List<AnswerOption> AnswerOptions { get; set; }
        public virtual List<UserAnswer> QuestionUserAnswers { get; set; }
    }

}
