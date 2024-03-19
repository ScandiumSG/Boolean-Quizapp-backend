using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quizapp_backend.Migrations
{
    /// <inheritdoc />
    public partial class tst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 1,
                column: "text",
                value: "4");

            migrationBuilder.InsertData(
                table: "answer_options",
                columns: new[] { "id", "is_correct", "question_id", "text" },
                values: new object[] { 2, false, 1, "3" });

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 1,
                column: "text",
                value: "What is 2 + 2?");

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "order", "quiz_id", "text" },
                values: new object[] { 2, 0, 1, "What is the capital of France?" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "title" },
                values: new object[] { "Test your math skills", "Math Quiz" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email", "password", "username" },
                values: new object[] { "user1@example.com", "password1", "user1" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "password", "username" },
                values: new object[,]
                {
                    { 2, "user2@example.com", "password2", "user2" },
                    { 3, "user3@example.com", "password3", "user3" }
                });

            migrationBuilder.InsertData(
                table: "answer_options",
                columns: new[] { "id", "is_correct", "question_id", "text" },
                values: new object[,]
                {
                    { 3, true, 2, "Paris" },
                    { 4, false, 2, "London" }
                });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "id", "description", "title", "user_id" },
                values: new object[,]
                {
                    { 2, "Test your knowledge of history", "History Quiz", 2 },
                    { 3, "Test your understanding of science concepts", "Science Quiz", 3 }
                });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "order", "quiz_id", "text" },
                values: new object[,]
                {
                    { 3, 0, 2, "Who was the first president of the United States?" },
                    { 4, 0, 2, "In which year did World War II end?" },
                    { 5, 0, 3, "What is the chemical symbol for water?" },
                    { 6, 0, 3, "What is the process by which plants make their own food?" }
                });

            migrationBuilder.InsertData(
                table: "user_answers",
                columns: new[] { "id", "user_answer_id", "answer_option_id" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.InsertData(
                table: "answer_options",
                columns: new[] { "id", "is_correct", "question_id", "text" },
                values: new object[,]
                {
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
                columns: new[] { "id", "user_answer_id", "answer_option_id" },
                values: new object[,]
                {
                    { 3, 2, 5 },
                    { 4, 2, 7 },
                    { 5, 3, 9 },
                    { 6, 3, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "id", "user_answer_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "id", "user_answer_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "id", "user_answer_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "id", "user_answer_id" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "id", "user_answer_id" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "users");

            migrationBuilder.DropColumn(
                name: "username",
                table: "users");

            migrationBuilder.UpdateData(
                table: "answer_options",
                keyColumn: "id",
                keyValue: 1,
                column: "text",
                value: "Answer 1");

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 1,
                column: "text",
                value: "Question 1");

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "title" },
                values: new object[] { "This is quiz 1", "Quiz 1" });
        }
    }
}
