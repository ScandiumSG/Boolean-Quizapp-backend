﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quizapp_backend.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attempt",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    quiz_id = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    highest_possible_score = table.Column<int>(type: "integer", nullable: false),
                    correct = table.Column<int>(type: "integer", nullable: false),
                    wrong = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attempt", x => new { x.user_id, x.quiz_id });
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_quizzes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz_id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_quizzes_quiz_id",
                        column: x => x.quiz_id,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_answer_options_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_answers",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    answer_option_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_answers", x => new { x.user_id, x.answer_option_id });
                    table.ForeignKey(
                        name: "FK_user_answers_answer_options_answer_option_id",
                        column: x => x.answer_option_id,
                        principalTable: "answer_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_answers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6adadc37-7e71-4eaa-9665-540c7e631b68", 0, "2538db3d-a00f-453e-92df-b275a36623b8", "user3@example.com", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEOsiyPhHj6r5Yr9MLEfWpnzrRqhlB/w+lCLskUPM/EKAonMAUYEo/qzn8vgwkYPUxg==", null, false, 0, "", false, "user3" },
                    { "91aa2f00-4887-42d5-a8df-2bc9ceb5da36", 0, "342bc1d2-2b74-4932-baaa-b8b7bf60020a", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEJZ/BzhEzR5OORur/sU9rrvGEZER0VM5nLtGHVTBLkGnL/8AVhIN0KTFJulVyQHyeg==", null, false, 0, "", false, "user2" },
                    { "e12feb36-3426-46f1-a020-b3673c259952", 0, "7de62ab5-8395-4028-bd4b-8f726db9ed72", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEEOrnLxPKe6Qc8rdmM159FmUTe7Tw69/x9EWwVr5wQ4LqFyypQqoN/uc4zaKV7l2VA==", null, false, 0, "", false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "id", "creation_date", "description", "title", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 21, 14, 5, 47, 573, DateTimeKind.Utc).AddTicks(6226), "Test your math skills", "Math Quiz", "e12feb36-3426-46f1-a020-b3673c259952" },
                    { 2, new DateTime(2024, 3, 20, 14, 5, 47, 573, DateTimeKind.Utc).AddTicks(6226), "Test your knowledge of history", "History Quiz", "91aa2f00-4887-42d5-a8df-2bc9ceb5da36" },
                    { 3, new DateTime(2024, 3, 19, 14, 5, 47, 573, DateTimeKind.Utc).AddTicks(6226), "Test your understanding of science concepts", "Science Quiz", "6adadc37-7e71-4eaa-9665-540c7e631b68" }
                });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "order", "quiz_id", "text" },
                values: new object[,]
                {
                    { 1, 0, 1, "What is 2 + 2?" },
                    { 2, 0, 1, "What is the capital of France?" },
                    { 3, 0, 2, "Who was the first president of the United States?" },
                    { 4, 0, 2, "In which year did World War II end?" },
                    { 5, 0, 3, "What is the chemical symbol for water?" },
                    { 6, 0, 3, "What is the process by which plants make their own food?" }
                });

            migrationBuilder.InsertData(
                table: "answer_options",
                columns: new[] { "id", "is_correct", "question_id", "text" },
                values: new object[,]
                {
                    { 1, true, 1, "4" },
                    { 2, false, 1, "3" },
                    { 3, true, 2, "Paris" },
                    { 4, false, 2, "London" },
                    { 5, true, 3, "George Washington" },
                    { 6, false, 3, "Thomas Jefferson" },
                    { 7, true, 4, "1945" },
                    { 8, false, 4, "1918" },
                    { 9, true, 5, "H2O" },
                    { 10, false, 5, "CO2" },
                    { 11, true, 6, "Photosynthesis" },
                    { 12, false, 6, "Respiration" }
                });

            migrationBuilder.InsertData(
                table: "user_answers",
                columns: new[] { "answer_option_id", "user_id" },
                values: new object[,]
                {
                    { 9, "6adadc37-7e71-4eaa-9665-540c7e631b68" },
                    { 11, "6adadc37-7e71-4eaa-9665-540c7e631b68" },
                    { 5, "91aa2f00-4887-42d5-a8df-2bc9ceb5da36" },
                    { 7, "91aa2f00-4887-42d5-a8df-2bc9ceb5da36" },
                    { 1, "e12feb36-3426-46f1-a020-b3673c259952" },
                    { 3, "e12feb36-3426-46f1-a020-b3673c259952" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_answer_options_question_id",
                table: "answer_options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_quiz_id",
                table: "questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_user_id",
                table: "quizzes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_answers_answer_option_id",
                table: "user_answers",
                column: "answer_option_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attempt");

            migrationBuilder.DropTable(
                name: "user_answers");

            migrationBuilder.DropTable(
                name: "answer_options");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
