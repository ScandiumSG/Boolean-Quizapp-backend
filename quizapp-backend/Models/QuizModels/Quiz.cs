using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.UserModels;

namespace quizapp_backend.Models.QuizModels
{
    [Table("quizzes")]
    public class Quiz
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Question>? Questions { get; set; }
    }
}
