using System;
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
                name: "QuizUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizUser_users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
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
                    order = table.Column<int>(type: "integer", nullable: false),
                    QuizUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_QuizUser_QuizUserId",
                        column: x => x.QuizUserId,
                        principalTable: "QuizUser",
                        principalColumn: "Id");
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    answer_option_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_answers", x => new { x.id, x.user_id });
                    table.ForeignKey(
                        name: "FK_user_answers_answer_options_answer_option_id",
                        column: x => x.answer_option_id,
                        principalTable: "answer_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_answers_questions_id",
                        column: x => x.id,
                        principalTable: "questions",
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
                    { "1b5ad32b-1729-495c-b9d2-9b5ba189cc51", 0, "c8fdefbe-5dd4-49e0-b22c-782a12e1c07f", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEFsG8q6rNJ+iavGBI95PjKfSynnzYoCKwd6y3fG7xOUMj0XoGZKfzq+6crVbnThxEg==", null, false, 1, "", false, "user2" },
                    { "4d2b9157-8675-4f83-a2a1-5b2d261167da", 0, "0b8ec9cb-6157-4663-ab6f-1a5a0e90cbcb", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEOLpp+ob86LvyMnz5tFZrvU3k1MuK0Hp3xtn8tfnDqxC77MIYPOqL0NbKc4AoBznFQ==", null, false, 1, "", false, "user1" },
                    { "da497de6-95d3-47b2-8f4b-7262a2bd5cc4", 0, "b5e7dc26-4c90-47f3-b77d-7ca1d5341224", "user3@example.com", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEPaHfeYBQmfccF8TXi980RISMK2m1/rtMWI7RzV+9LVGAwbG4Rr88sD/p9j4UMV40A==", null, false, 1, "", false, "user3" }
                });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "id", "description", "title", "user_id" },
                values: new object[,]
                {
                    { 1, "Test your math skills", "Math Quiz", "4d2b9157-8675-4f83-a2a1-5b2d261167da" },
                    { 2, "Test your knowledge of history", "History Quiz", "1b5ad32b-1729-495c-b9d2-9b5ba189cc51" },
                    { 3, "Test your understanding of science concepts", "Science Quiz", "da497de6-95d3-47b2-8f4b-7262a2bd5cc4" }
                });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "order", "quiz_id", "QuizUserId", "text" },
                values: new object[,]
                {
                    { 1, 0, 1, null, "What is 2 + 2?" },
                    { 2, 0, 1, null, "What is the capital of France?" },
                    { 3, 0, 2, null, "Who was the first president of the United States?" },
                    { 4, 0, 2, null, "In which year did World War II end?" },
                    { 5, 0, 3, null, "What is the chemical symbol for water?" },
                    { 6, 0, 3, null, "What is the process by which plants make their own food?" }
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
                columns: new[] { "id", "user_id", "answer_option_id" },
                values: new object[,]
                {
                    { 1, "4d2b9157-8675-4f83-a2a1-5b2d261167da", 1 },
                    { 2, "4d2b9157-8675-4f83-a2a1-5b2d261167da", 3 },
                    { 3, "1b5ad32b-1729-495c-b9d2-9b5ba189cc51", 5 },
                    { 4, "1b5ad32b-1729-495c-b9d2-9b5ba189cc51", 7 },
                    { 5, "da497de6-95d3-47b2-8f4b-7262a2bd5cc4", 9 },
                    { 6, "da497de6-95d3-47b2-8f4b-7262a2bd5cc4", 11 }
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
                name: "IX_questions_QuizUserId",
                table: "questions",
                column: "QuizUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUser_ApplicationUserId",
                table: "QuizUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_user_id",
                table: "quizzes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_answers_answer_option_id",
                table: "user_answers",
                column: "answer_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_answers_user_id",
                table: "user_answers",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_answers");

            migrationBuilder.DropTable(
                name: "answer_options");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "QuizUser");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
