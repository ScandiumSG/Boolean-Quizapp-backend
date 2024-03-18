using Microsoft.EntityFrameworkCore;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;

namespace quizapp_backend.Database
{
    public class Seeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1 });

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { Id = 1, UserId = 1, Title = "Quiz 1", Description = "This is quiz 1" });

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuizId = 1, Text = "Question 1" });

            modelBuilder.Entity<AnswerOption>().HasData(
                new AnswerOption { Id = 1, QuestionId = 1, Text = "Answer 1", IsCorrect = true });

            modelBuilder.Entity<UserAnswer>().HasData(
                new UserAnswer { QuestionId = 1, UserId = 1, AnswerOptionId = 1 });
        }
    }
}
