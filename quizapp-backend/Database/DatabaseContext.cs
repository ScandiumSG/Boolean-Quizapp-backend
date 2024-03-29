﻿using Microsoft.EntityFrameworkCore;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.ScoreModels;
using quizapp_backend.Models.UserModels;

namespace quizapp_backend.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<UserAnswer> QuestionUserAnswers { get; set; }
        public DbSet<Attempt> Attempts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().Navigation(q => q.Questions).AutoInclude();
            modelBuilder.Entity<Quiz>().Navigation(q => q.User).AutoInclude();
            modelBuilder.Entity<Question>().Navigation(q => q.AnswerOptions).AutoInclude();
            modelBuilder.Entity<ApplicationUser>().Navigation(q => q.Quizzes).AutoInclude();
            modelBuilder.Entity<ApplicationUser>().Navigation(q => q.UserAnswers).AutoInclude();

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Quiz>()
            //    .HasMany(q => q.Attempts)
            //    .WithOne(a => a.Quiz)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerOptions)
                .WithOne(a => a.Question)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnswerOption>()
                .HasMany(a => a.UserAnswers)
                .WithOne(u => u.AnswerOption);

            modelBuilder.Entity<UserAnswer>()
                .HasKey(q => new { q.UserId, q.AnswerOptionId });

            modelBuilder.Entity<Attempt>()
                .HasKey(q => new { q.UserId, q.QuizId });

            Seeder.SeedData(modelBuilder);
        }


        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                await Database.ExecuteSqlRawAsync("SELECT 1");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
