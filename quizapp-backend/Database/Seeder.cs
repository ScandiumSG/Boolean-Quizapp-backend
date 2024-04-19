using Microsoft.AspNetCore.Identity;
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
            // Identity Users
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Bob",
                    NormalizedUserName = "Bob",
                    Email = "bob@brainbox.com",
                    NormalizedEmail = "BOB@BRAINBOX.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password1"),
                    SecurityStamp = string.Empty,
                    Role = Role.Admin
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Bob's wife",
                    NormalizedUserName = "BOBSWIFE",
                    Email = "bobswife@brainbox.com",
                    NormalizedEmail = "BOBSWIFE@BRAINBOX.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password1"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Bob's son",
                    NormalizedUserName = "BOBSSON",
                    Email = "bobsson@brainbox.com",
                    NormalizedEmail = "BOBSSON@BRAINBOX.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password1"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "ScandiumSG",
                    NormalizedUserName = "SCANDIUMSG",
                    Email = "stian.k.gaustad@gmail.com",
                    NormalizedEmail = "STIAN.K.GAUSTAD@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password123"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "tollov",
                    NormalizedUserName = "TOLLOV",
                    Email = "tollov@email.com",
                    NormalizedEmail = "TOLLOV@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password1"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
            };

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            // Quizzes
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan oneDay = TimeSpan.FromDays(1);

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { Id = 1, UserId = users[0].Id, Title = "Math Quiz", Description = "Test your math skills", CreationDate = currentDate },
                new Quiz { Id = 2, UserId = users[1].Id, Title = "History Quiz", Description = "Test your knowledge of history", CreationDate = currentDate - oneDay },
                new Quiz { Id = 3, UserId = users[2].Id, Title = "Science Quiz", Description = "Test your understanding of science concepts", CreationDate = currentDate - 2 * oneDay },
                new Quiz { Id = 5, UserId = users[3].Id, Title = "Country flag colors", Description = "What colors are present in various countries' flags?", 
                    CreationDate = currentDate - oneDay * 3},
                new Quiz { Id = 6, UserId = users[0].Id, Title = "Bagel Quiz", Description = "Test your knowledge about bagels", CreationDate = currentDate - oneDay * 4 }
           );

            // Questions
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuizId = 1, Text = "What is 2 + 2?", Order = 0 },
                new Question { Id = 2, QuizId = 1, Text = "What is the capital of France?", Order = 1 },
                new Question { Id = 3, QuizId = 2, Text = "Who was the first president of the United States?", Order = 0 },
                new Question { Id = 4, QuizId = 2, Text = "In which year did World War II end?", Order = 1 },
                new Question { Id = 5, QuizId = 3, Text = "What is the chemical symbol for water?", Order = 0 },
                new Question { Id = 6, QuizId = 3, Text = "What is the process by which plants make their own food?", Order = 1 },
                new Question { Id = 7, QuizId = 5, Text = "France", Order = 0 },
                new Question { Id = 8, QuizId = 5, Text = "Singapore", Order = 1 },
                new Question { Id = 9, QuizId = 5, Text = "Senegal", Order = 2 },
                new Question { Id = 10, QuizId = 6, Text = "Where did bagels originate from?", Order = 0 },
                new Question { Id = 11, QuizId = 6, Text = "Which of the following are traditional toppings for a bagel?", Order = 1 },
                new Question { Id = 12, QuizId = 6, Text = "What are the main ingredients of a bagel?", Order = 2 }
            );

            // Answer Options
            modelBuilder.Entity<AnswerOption>().HasData(
                new AnswerOption { Id = 1, QuestionId = 1, Text = "4", IsCorrect = true },
                new AnswerOption { Id = 2, QuestionId = 1, Text = "3", IsCorrect = false },
                new AnswerOption { Id = 3, QuestionId = 2, Text = "Paris", IsCorrect = true },
                new AnswerOption { Id = 4, QuestionId = 2, Text = "London", IsCorrect = false },
                new AnswerOption { Id = 5, QuestionId = 3, Text = "George Washington", IsCorrect = true },
                new AnswerOption { Id = 6, QuestionId = 3, Text = "Thomas Jefferson", IsCorrect = false },
                new AnswerOption { Id = 7, QuestionId = 4, Text = "1945", IsCorrect = true },
                new AnswerOption { Id = 8, QuestionId = 4, Text = "1918", IsCorrect = false },
                new AnswerOption { Id = 9, QuestionId = 5, Text = "H2O", IsCorrect = true },
                new AnswerOption { Id = 10, QuestionId = 5, Text = "CO2", IsCorrect = false },
                new AnswerOption { Id = 11, QuestionId = 6, Text = "Photosynthesis", IsCorrect = true },
                new AnswerOption { Id = 12, QuestionId = 6, Text = "Respiration", IsCorrect = false },
                new AnswerOption { Id = 13, QuestionId = 7, Text = "Red", IsCorrect = true },
                new AnswerOption { Id = 14, QuestionId = 7, Text = "Green", IsCorrect = false },
                new AnswerOption { Id = 15, QuestionId = 7, Text = "White", IsCorrect = true },
                new AnswerOption { Id = 16, QuestionId = 7, Text = "Blue", IsCorrect = true },
                new AnswerOption { Id = 17, QuestionId = 7, Text = "Yellow", IsCorrect = false },
                new AnswerOption { Id = 18, QuestionId = 7, Text = "Black", IsCorrect = false },
                new AnswerOption { Id = 19, QuestionId = 8, Text = "Red", IsCorrect = true },
                new AnswerOption { Id = 20, QuestionId = 8, Text = "Green", IsCorrect = false },
                new AnswerOption { Id = 21, QuestionId = 8, Text = "White", IsCorrect = true },
                new AnswerOption { Id = 22, QuestionId = 8, Text = "Blue", IsCorrect = false },
                new AnswerOption { Id = 23, QuestionId = 8, Text = "Yellow", IsCorrect = false },
                new AnswerOption { Id = 24, QuestionId = 8, Text = "Black", IsCorrect = false },
                new AnswerOption { Id = 25, QuestionId = 8, Text = "Pink", IsCorrect = false },
                new AnswerOption { Id = 26, QuestionId = 9, Text = "Red", IsCorrect = true },
                new AnswerOption { Id = 27, QuestionId = 9, Text = "Green", IsCorrect = true },
                new AnswerOption { Id = 28, QuestionId = 9, Text = "White", IsCorrect = false },
                new AnswerOption { Id = 29, QuestionId = 9, Text = "Blue", IsCorrect = false },
                new AnswerOption { Id = 30, QuestionId = 9, Text = "Yellow", IsCorrect = true },
                new AnswerOption { Id = 31, QuestionId = 9, Text = "Black", IsCorrect = false },
                new AnswerOption { Id = 32, QuestionId = 10, Text = "Poland", IsCorrect = true },
                new AnswerOption { Id = 33, QuestionId = 10, Text = "France", IsCorrect = false },
                new AnswerOption { Id = 34, QuestionId = 10, Text = "Italy", IsCorrect = false },
                new AnswerOption { Id = 35, QuestionId = 10, Text = "Germany", IsCorrect = false },
                new AnswerOption { Id = 36, QuestionId = 12, Text = "Flour, water, yeast, salt", IsCorrect = true },
                new AnswerOption { Id = 37, QuestionId = 12, Text = "Milk, eggs, sugar, flour", IsCorrect = false },
                new AnswerOption { Id = 38, QuestionId = 12, Text = "Butter, sugar, flour, baking powder", IsCorrect = false },
                new AnswerOption { Id = 39, QuestionId = 12, Text = "Cornmeal, water, yeast, salt", IsCorrect = false },
                new AnswerOption { Id = 40, QuestionId = 11, Text = "Cream cheese", IsCorrect = true },
                new AnswerOption { Id = 41, QuestionId = 11, Text = "Smoked salmon", IsCorrect = true },
                new AnswerOption { Id = 42, QuestionId = 11, Text = "Tomato", IsCorrect = false },
                new AnswerOption { Id = 43, QuestionId = 11, Text = "Avocado", IsCorrect = true },
                new AnswerOption { Id = 44, QuestionId = 11, Text = "Peanut butter", IsCorrect = false }
            );

            // User Answers (for demonstration purposes)
            modelBuilder.Entity<UserAnswer>().HasData(
                new UserAnswer { UserId = users[0].Id, AnswerOptionId = 1 },
                new UserAnswer { UserId = users[0].Id, AnswerOptionId = 3 },
                new UserAnswer { UserId = users[1].Id, AnswerOptionId = 5 },
                new UserAnswer { UserId = users[1].Id, AnswerOptionId = 7 },
                new UserAnswer { UserId = users[2].Id, AnswerOptionId = 9 },
                new UserAnswer { UserId = users[2].Id, AnswerOptionId = 11});
        }
    }
}
