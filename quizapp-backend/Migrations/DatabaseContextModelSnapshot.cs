﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using quizapp_backend.Database;

#nullable disable

namespace quizapp_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<int>("AnswerOptionId")
                        .HasColumnType("integer")
                        .HasColumnName("answer_option_id");

                    b.HasKey("QuestionId", "UserId");

                    b.HasIndex("AnswerOptionId");

                    b.HasIndex("UserId");

                    b.ToTable("user_answers");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            UserId = "46f1970a-c9f1-44fe-9223-ed41211eeefb",
                            AnswerOptionId = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            UserId = "46f1970a-c9f1-44fe-9223-ed41211eeefb",
                            AnswerOptionId = 3
                        },
                        new
                        {
                            QuestionId = 3,
                            UserId = "d3df97ef-10a0-4e6c-8e00-5dcda4a2d3af",
                            AnswerOptionId = 5
                        },
                        new
                        {
                            QuestionId = 4,
                            UserId = "d3df97ef-10a0-4e6c-8e00-5dcda4a2d3af",
                            AnswerOptionId = 7
                        },
                        new
                        {
                            QuestionId = 5,
                            UserId = "daa46d5a-24da-4494-81c6-b013b059d7ba",
                            AnswerOptionId = 9
                        },
                        new
                        {
                            QuestionId = 6,
                            UserId = "daa46d5a-24da-4494-81c6-b013b059d7ba",
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
                            UserId = "46f1970a-c9f1-44fe-9223-ed41211eeefb"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test your knowledge of history",
                            Title = "History Quiz",
                            UserId = "d3df97ef-10a0-4e6c-8e00-5dcda4a2d3af"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test your understanding of science concepts",
                            Title = "Science Quiz",
                            UserId = "daa46d5a-24da-4494-81c6-b013b059d7ba"
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
                            Id = "46f1970a-c9f1-44fe-9223-ed41211eeefb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "80cc7b38-0dac-40d7-83f7-f7ac0c0df147",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEAoxQ57/a9rq4QBcbVdd3qsZJqiwpV5Kmqpluis68EGm6sv4ijLixL415wYv0vg8Ww==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "d3df97ef-10a0-4e6c-8e00-5dcda4a2d3af",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8fb15c78-7263-4f0b-8e9d-68115131f5ad",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEGVJMSBQS+7pGRReVWuqVM9J2FJ1WJX6g/0auKEh8LKKLiWchcT5MZu/w1/KiHWdaQ==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "daa46d5a-24da-4494-81c6-b013b059d7ba",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "caa895c6-83b9-4485-bf21-fd19c39341f7",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAIAAYagAAAAEOLhiVFMxSnTrG10yxKeS4fHBZFlVFVbv0qHcARyP3ZIPXsafwHgDpFI9zEwTHESow==",
                            PhoneNumberConfirmed = false,
                            Role = 1,
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

                    b.HasOne("quizapp_backend.Models.QuestionModels.Question", "Question")
                        .WithMany("QuestionUserAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quizapp_backend.Models.UserModels.ApplicationUser", "User")
                        .WithMany("QuestionUserAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerOption");

                    b.Navigation("Question");

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
                    b.Navigation("QuestionUserAnswers");

                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
