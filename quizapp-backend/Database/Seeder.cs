using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;
using System;
using System.Collections.Generic;

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
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password1"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password2"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user3",
                    NormalizedUserName = "USER3",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "password3"),
                    SecurityStamp = string.Empty,
                    Role = Role.User
                }
            };

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            // Quizzes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { Id = 1, UserId = users[0].Id, Title = "Math Quiz", Description = "Test your math skills" },
                new Quiz { Id = 2, UserId = users[1].Id, Title = "History Quiz", Description = "Test your knowledge of history" },
                new Quiz { Id = 3, UserId = users[2].Id, Title = "Science Quiz", Description = "Test your understanding of science concepts" });

            // Questions
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuizId = 1, Text = "What is 2 + 2?" },
                new Question { Id = 2, QuizId = 1, Text = "What is the capital of France?" },
                new Question { Id = 3, QuizId = 2, Text = "Who was the first president of the United States?" },
                new Question { Id = 4, QuizId = 2, Text = "In which year did World War II end?" },
                new Question { Id = 5, QuizId = 3, Text = "What is the chemical symbol for water?" },
                new Question { Id = 6, QuizId = 3, Text = "What is the process by which plants make their own food?" });

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
                new AnswerOption { Id = 12, QuestionId = 6, Text = "Respiration", IsCorrect = false });

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
