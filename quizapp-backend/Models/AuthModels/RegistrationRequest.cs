﻿using System.ComponentModel.DataAnnotations;

namespace quizapp_backend.Models.AuthModels
{
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}