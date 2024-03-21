﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using quizapp_backend.Database;

#nullable disable

namespace quizapp_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240321073143_removeQuizIdFromUserAnswer")]
    partial class removeQuizIdFromUserAnswer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("quizapp_backend.Models.AnswerOptionModels.AnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean")
                        .HasColumnName("is_correct");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer")
                        .HasColumnName("question_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("answer_options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCorrect = true,
                            QuestionId = 1,
                            Text = "4"
                        },
                        new
                        {
                            Id = 2,
                            IsCorrect = false,
                            QuestionId = 1,
                            Text = "3"
                        },
                        new
                        {
                            Id = 3,
                            IsCorrect = true,
                            QuestionId = 2,
                            Text = "Paris"
                        },
                        new
                        {
                            Id = 4,
                            IsCorrect = false,
                            QuestionId = 2,
                            Text = "London"
                        },
                        new
                        {
                            Id = 5,
                            IsCorrect = true,
                            QuestionId = 3,
                            Text = "George Washington"
                        },
                        new
                        {
                            Id = 6,
                            IsCorrect = false,
                            QuestionId = 3,
                            Text = "Thomas Jefferson"
                        },
                        new
                        {
                            Id = 7,
                            IsCorrect = true,
                            QuestionId = 4,
                            Text = "1945"
                        },
                        new
                        {
                            Id = 8,
                            IsCorrect = false,
                            QuestionId = 4,
                            Text = "1918"
                        },
                        new
                        {
                            Id = 9,
                            IsCorrect = true,
                            QuestionId = 5,
                            Text = "H2O"
                        },
                        new
                        {
                            Id = 10,
                            IsCorrect = false,
                            QuestionId = 5,
                            Text = "CO2"
                        },
                        new
                        {
                            Id = 11,
                            IsCorrect = true,
                            QuestionId = 6,
                            Text = "Photosynthesis"
                        },
                        new
                        {
                            Id = 12,
                            IsCorrect = false,
                            QuestionId = 6,
                            Text = "Respiration"
                        });
                });

            modelBuilder.Entity("quizapp_backend.Models.QuestionModels.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("order");

                    b.Property<int>("QuizId")
                        .HasColumnType("integer")
                        .HasColumnName("quiz_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Order = 0,
                            QuizId = 1,
                            Text = "What is 2 + 2?"
                        },
                        new
                        {
                            Id = 2,
                            Order = 0,
                            QuizId = 1,
                            Text = "What is the capital of France?"
                        },
                        new
                        {
                            Id = 3,
                            Order = 0,
                            QuizId = 2,
                            Text = "Who was the first president of the United States?"
                        },
                        new
                        {
                            Id = 4,
                            Order = 0,
                            QuizId = 2,
                            Text = "In which year did World War II end?"
                        },
                        new
                        {
                            Id = 5,
                            Order = 0,
                            QuizId = 3,
                            Text = "What is the chemical symbol for water?"
                        },
                        new
                        {
                            Id = 6,
                            Order = 0,
                            QuizId = 3,
                            Text = "What is the process by which plants make their own food?"
                        });
                });

            modelBuilder.Entity("quizapp_backend.Models.QuestionUserAnswerModels.UserAnswer", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<int>("AnswerOptionId")
                        .HasColumnType("integer")
                        .HasColumnName("answer_option_id");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "AnswerOptionId");

                    b.HasIndex("AnswerOptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("user_answers");

                    b.HasData(
                        new
                        {
                            UserId = "b09aeb0e-22a3-449a-8c70-82d14827504c",
                            AnswerOptionId = 1
                        },
                        new
                        {
                            UserId = "b09aeb0e-22a3-449a-8c70-82d14827504c",
                            AnswerOptionId = 3
                        },
                        new
                        {
                            UserId = "ac4f89c4-ff21-4290-a13d-2927e9869880",
                            AnswerOptionId = 5
                        },
                        new
                        {
                            UserId = "ac4f89c4-ff21-4290-a13d-2927e9869880",
                            AnswerOptionId = 7
                        },
                        new
                        {
                            UserId = "4e28b9f0-e9de-4e1b-99d2-b5c8d037ca91",
                            AnswerOptionId = 9
                        },
                        new
                        {
                            UserId = "4e28b9f0-e9de-4e1b-99d2-b5c8d037ca91",
                            AnswerOptionId = 11
                        });
                });

            modelBuilder.Entity("quizapp_backend.Models.QuizModels.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test your math skills",
                            Title = "Math Quiz",
                            UserId = "b09aeb0e-22a3-449a-8c70-82d14827504c"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test your knowledge of history",
                            Title = "History Quiz",
                            UserId = "ac4f89c4-ff21-4290-a13d-2927e9869880"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test your understanding of science concepts",
                            Title = "Science Quiz",
                            UserId = "4e28b9f0-e9de-4e1b-99d2-b5c8d037ca91"
                        });
                });

            modelBuilder.Entity("quizapp_backend.Models.UserModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = "b09aeb0e-22a3-449a-8c70-82d14827504c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6d5f3630-973e-4855-885c-5307a2d99d4d",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEH+j8qV81hde/fAQ6JUesESTKll+RzGHvmAJFmr53yA+EHnn4+dXwY2xSBR8gmwTwQ==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "ac4f89c4-ff21-4290-a13d-2927e9869880",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b70c75ff-6145-4844-aa42-d08996294be8",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEAZGFieiBm1AnF1GC/h6Zqg1x9sqXu1eF4fY+X33WdRXtEuQonLeKXdNkZw7gKmSvA==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "4e28b9f0-e9de-4e1b-99d2-b5c8d037ca91",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bbd60fa0-569e-49c2-8612-b57bb2d45172",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAIAAYagAAAAEF1aX1QoMjdFFWt6do4fJ63A6RARcy6HZ47RlfVy7CUujW9xbm5H4bv+seITjgZX9w==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        });
                });

            modelBuilder.Entity("quizapp_backend.Models.AnswerOptionModels.AnswerOption", b =>
                {
                    b.HasOne("quizapp_backend.Models.QuestionModels.Question", "Question")
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("quizapp_backend.Models.QuestionModels.Question", b =>
                {
                    b.HasOne("quizapp_backend.Models.QuizModels.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("quizapp_backend.Models.QuestionUserAnswerModels.UserAnswer", b =>
                {
                    b.HasOne("quizapp_backend.Models.AnswerOptionModels.AnswerOption", "AnswerOption")
                        .WithMany()
                        .HasForeignKey("AnswerOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quizapp_backend.Models.QuestionModels.Question", null)
                        .WithMany("QuestionUserAnswers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("quizapp_backend.Models.UserModels.ApplicationUser", "User")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerOption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("quizapp_backend.Models.QuizModels.Quiz", b =>
                {
                    b.HasOne("quizapp_backend.Models.UserModels.ApplicationUser", "User")
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("quizapp_backend.Models.QuestionModels.Question", b =>
                {
                    b.Navigation("AnswerOptions");

                    b.Navigation("QuestionUserAnswers");
                });

            modelBuilder.Entity("quizapp_backend.Models.QuizModels.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("quizapp_backend.Models.UserModels.ApplicationUser", b =>
                {
                    b.Navigation("Quizzes");

                    b.Navigation("UserAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}