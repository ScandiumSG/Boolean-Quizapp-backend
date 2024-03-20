using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;

namespace quizapp_backend.Models.UserModels
{
    public class UserOutput
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<QuizUser> Quizzes { get; set; }
        public virtual ICollection<OutputUserAnswer> UserAnswers { get; set; }
    }
}
