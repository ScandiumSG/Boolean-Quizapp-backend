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
                    { "289daf69-44ca-4ad1-8f2b-9bb4b6fa5482", 0, "67625a5e-26ad-4d8f-82bd-e01da8c82f2d", "tollov@email.com", true, false, null, "TOLLOV@EMAIL.COM", "TOLLOV", "AQAAAAIAAYagAAAAEC6d9rJJbEyf21KGZFbwvuAiy5GFpiefqoS05XLvVn4d6EbMivBYokd7C7mX0wzjNw==", null, false, 0, "", false, "tollov" },
                    { "5a60c9b8-c68b-4779-9f93-b60ffa22c356", 0, "58a6e36e-be54-4d2e-ac52-aeb4cb3e4e30", "stian.k.gaustad@gmail.com", true, false, null, "STIAN.K.GAUSTAD@GMAIL.COM", "SCANDIUMSG", "AQAAAAIAAYagAAAAEJM8ecUv/l3QeVCTiCc9Bckh8wKCaVv/d1Kda6vfRweQGI7YpbGfzw1hzdAnrL3yLg==", null, false, 0, "", false, "ScandiumSG" },
                    { "719994b4-0509-4cc3-a089-c7591fb77468", 0, "79104f43-846d-47d6-a28e-b26f851172df", "bobswife@brainbox.com", true, false, null, "BOBSWIFE@BRAINBOX.COM", "BOBSWIFE", "AQAAAAIAAYagAAAAEBD0Pnb79C7vR2iPcVttuESkVm2qYBCALXVW0wTEs+PXlvHnsV59x28f2+aTI0iEoQ==", null, false, 0, "", false, "Bob's wife" },
                    { "b5d56b03-a018-436c-a0c3-ad0b13ac94d7", 0, "aa7703ec-c0d0-4edf-ac3a-eb001a4f672b", "bobsson@brainbox.com", true, false, null, "BOBSSON@BRAINBOX.COM", "BOBSSON", "AQAAAAIAAYagAAAAEFLv7kOJbEnGpFmvoSd/xmc428nUHyozB3qFDbBbBHXIansZ42CIGeT0ByuEusQ59A==", null, false, 0, "", false, "Bob's son" },
                    { "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8", 0, "f0fde883-f381-48c6-8794-cff4f04db2a7", "bob@brainbox.com", true, false, null, "BOB@BRAINBOX.COM", "Bob", "AQAAAAIAAYagAAAAEOS6ud9x/SWrI/BAjgw9pJLbDpojQxiw0YdqiKPyV+UeWfuewGMbHLA+B1OTG0jjQQ==", null, false, 1, "", false, "Bob" }
                });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "id", "creation_date", "description", "title", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 22, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "Test your math skills", "Math Quiz", "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" },
                    { 2, new DateTime(2024, 3, 21, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "Test your knowledge of history", "History Quiz", "719994b4-0509-4cc3-a089-c7591fb77468" },
                    { 3, new DateTime(2024, 3, 20, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "Test your understanding of science concepts", "Science Quiz", "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" },
                    { 5, new DateTime(2024, 3, 19, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "What colors are present in various countries' flags?", "Country flag colors", "5a60c9b8-c68b-4779-9f93-b60ffa22c356" },
                    { 6, new DateTime(2024, 3, 18, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "Test your knowledge about bagels", "Bagel Quiz", "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" }
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
                    { 6, 0, 3, "What is the process by which plants make their own food?" },
                    { 7, 0, 5, "France" },
                    { 8, 0, 5, "Singapore" },
                    { 9, 0, 5, "Senegal" },
                    { 10, 0, 6, "Where did bagels originate from?" },
                    { 11, 0, 6, "Which of the following are traditional toppings for a bagel?" },
                    { 12, 0, 6, "What are the main ingredients of a bagel?" }
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
                    { 12, false, 6, "Respiration" },
                    { 13, false, 7, "Red" },
                    { 14, false, 7, "Green" },
                    { 15, false, 7, "White" },
                    { 16, false, 7, "Blue" },
                    { 17, false, 7, "Yellow" },
                    { 18, false, 7, "Black" },
                    { 19, false, 8, "Red" },
                    { 20, false, 8, "Green" },
                    { 21, false, 8, "White" },
                    { 22, false, 8, "Blue" },
                    { 23, false, 8, "Yellow" },
                    { 24, false, 8, "Black" },
                    { 25, false, 8, "Pink" },
                    { 26, false, 9, "Red" },
                    { 27, false, 9, "Green" },
                    { 28, false, 9, "White" },
                    { 29, false, 9, "Blue" },
                    { 30, false, 9, "Yellow" },
                    { 31, false, 9, "Black" },
                    { 32, true, 10, "Poland" },
                    { 33, false, 10, "France" },
                    { 34, false, 10, "Italy" },
                    { 35, false, 10, "Germany" },
                    { 36, true, 12, "Flour, water, yeast, salt" },
                    { 37, false, 12, "Milk, eggs, sugar, flour" },
                    { 38, false, 12, "Butter, sugar, flour, baking powder" },
                    { 39, false, 12, "Cornmeal, water, yeast, salt" },
                    { 40, true, 11, "Cream cheese" },
                    { 41, true, 11, "Smoked salmon" },
                    { 42, false, 11, "Tomato" },
                    { 43, true, 11, "Avocado" },
                    { 44, false, 11, "Peanut butter" }
                });

            migrationBuilder.InsertData(
                table: "user_answers",
                columns: new[] { "answer_option_id", "user_id" },
                values: new object[,]
                {
                    { 5, "719994b4-0509-4cc3-a089-c7591fb77468" },
                    { 7, "719994b4-0509-4cc3-a089-c7591fb77468" },
                    { 9, "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" },
                    { 11, "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" },
                    { 1, "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" },
                    { 3, "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" }
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
