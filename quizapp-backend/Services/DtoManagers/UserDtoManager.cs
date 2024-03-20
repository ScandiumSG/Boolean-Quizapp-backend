using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;

namespace quizapp_backend.Services.DtoManagers
{
    public static class UserDtoManager
    {
        public static UserOutput Convert(ApplicationUser user)
        {
            return new UserOutput
            {
                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                Role = user.Role,
                Quizzes = QuizDtoManager.ConvertUser(user.Quizzes),
                UserAnswers = user.UserAnswers != null ? UserAnswerDtoManager.ConvertUser(user.UserAnswers) : new List<OutputUserAnswer>(),
            };
        }

        public static ICollection<UserOutput> Convert(ICollection<ApplicationUser> users)
        {
            return users.Select(Convert).ToList();
        }
    }
}
