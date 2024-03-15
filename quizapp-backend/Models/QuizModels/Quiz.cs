using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizapp_backend.Models.QuizModels
{
    [Table("quizzes")]
    public class Quiz
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        
        public virtual User User { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
