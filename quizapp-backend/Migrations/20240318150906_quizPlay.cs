using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizapp_backend.Migrations
{
    /// <inheritdoc />
    public partial class quizPlay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 1,
                column: "order",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                table: "questions");
        }
    }
}
