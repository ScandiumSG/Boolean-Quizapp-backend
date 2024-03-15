using quizapp_backend.Models.QuestionModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.AnswerOptionModels
{
    [Table("answer_options")]
    public class AnswerOption
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("question_id")]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("is_correct")]
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
    }

}
