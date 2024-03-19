using Microsoft.AspNetCore.Identity;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

public enum Role
{
    Admin,
    User
}

namespace quizapp_backend.Models.UserModels
{
    [Table("users")]
    public class ApplicationUser : IdentityUser
    {
        [Column("role")]
        public Role Role { get; set; }

        public virtual List<Quiz> Quizzes { get; set; }
        public virtual List<UserAnswer> QuestionUserAnswers { get; set; }
    }
}
