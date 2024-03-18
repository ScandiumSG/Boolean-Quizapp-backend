using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz_id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    user_answer_id = table.Column<int>(type: "integer", nullable: false),
                    answer_option_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_answers", x => new { x.id, x.user_answer_id });
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
                        name: "FK_user_answers_users_user_answer_id",
                        column: x => x.user_answer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                column: "id",
                value: 1);

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "id", "description", "title", "user_id" },
                values: new object[] { 1, "This is quiz 1", "Quiz 1", 1 });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "quiz_id", "text" },
                values: new object[] { 1, 1, "Question 1" });

            migrationBuilder.InsertData(
                table: "answer_options",
                columns: new[] { "id", "is_correct", "question_id", "text" },
                values: new object[] { 1, true, 1, "Answer 1" });

            migrationBuilder.InsertData(
                table: "user_answers",
                columns: new[] { "id", "user_answer_id", "answer_option_id" },
                values: new object[] { 1, 1, 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_user_answers_user_answer_id",
                table: "user_answers",
                column: "user_answer_id");
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
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
