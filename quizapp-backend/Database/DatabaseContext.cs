
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using quizapp_backend.Models.AnswerOptionModels;
using quizapp_backend.Models.QuestionModels;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.UserModels;
using System.Diagnostics;

namespace quizapp_backend.Database
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<QuestionUserAnswer> QuestionUserAnswers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            _connectionString = options.FindExtension<NpgsqlOptionsExtension>()?.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionUserAnswer>()
                .HasKey(q => new { q.QuestionId, q.UserId });
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
