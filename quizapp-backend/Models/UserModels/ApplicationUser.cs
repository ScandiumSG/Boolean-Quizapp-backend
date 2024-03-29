﻿using Microsoft.AspNetCore.Identity;
using quizapp_backend.Models.QuestionUserAnswerModels;
using quizapp_backend.Models.QuizModels;
using quizapp_backend.Models.ScoreModels;
using System.ComponentModel.DataAnnotations.Schema;

public enum Role
{
    User,
    Admin
}

namespace quizapp_backend.Models.UserModels
{
    [Table("users")]
    public class ApplicationUser : IdentityUser
    {
        [Column("role")]
        public Role Role { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        //public virtual ICollection<Attempt>? Attempts { get; set; }

    }
}
