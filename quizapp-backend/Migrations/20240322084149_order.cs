using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quizapp_backend.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 5, "719994b4-0509-4cc3-a089-c7591fb77468" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 7, "719994b4-0509-4cc3-a089-c7591fb77468" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 9, "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 11, "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 1, "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 3, "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" });

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "289daf69-44ca-4ad1-8f2b-9bb4b6fa5482");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "5a60c9b8-c68b-4779-9f93-b60ffa22c356");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "719994b4-0509-4cc3-a089-c7591fb77468");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "b5d56b03-a018-436c-a0c3-ad0b13ac94d7");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8");

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 2,
                column: "order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 4,
                column: "order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 6,
                column: "order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 8,
                column: "order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 9,
                column: "order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 11,
                column: "order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 12,
                column: "order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 22, 8, 41, 49, 526, DateTimeKind.Utc).AddTicks(8860), "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 21, 8, 41, 49, 526, DateTimeKind.Utc).AddTicks(8860), "d709b64a-2b0d-489a-b979-b264fbd2301a" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 20, 8, 41, 49, 526, DateTimeKind.Utc).AddTicks(8860), "6db6382f-ca07-4d1e-9a75-4357b609f248" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 19, 8, 41, 49, 526, DateTimeKind.Utc).AddTicks(8860), "220420f1-3bd8-4e83-a731-766981c092ca" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 18, 8, 41, 49, 526, DateTimeKind.Utc).AddTicks(8860), "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "220420f1-3bd8-4e83-a731-766981c092ca", 0, "79cdb143-a36d-482e-b88c-f06483310481", "stian.k.gaustad@gmail.com", true, false, null, "STIAN.K.GAUSTAD@GMAIL.COM", "SCANDIUMSG", "AQAAAAIAAYagAAAAEG60jTX3vgfdpsvOJjHGXfMsFaHuKf+J5PwnY5Lpn60aNSr+CX9i61QP7F+TJixQWw==", null, false, 0, "", false, "ScandiumSG" },
                    { "6db6382f-ca07-4d1e-9a75-4357b609f248", 0, "5365e37b-f9f9-413d-8d07-bcf8ea207319", "bobsson@brainbox.com", true, false, null, "BOBSSON@BRAINBOX.COM", "BOBSSON", "AQAAAAIAAYagAAAAEBAYSxutuQWyEv21SZzxyqBxfriX83ufpItokKiAq//Yl3Xic17UX819J5G7KQxawQ==", null, false, 0, "", false, "Bob's son" },
                    { "8389617c-5e8a-40b4-9131-ff6647aa6dde", 0, "4f10e68b-1bd6-4f8f-aaa7-bc6a652a2320", "tollov@email.com", true, false, null, "TOLLOV@EMAIL.COM", "TOLLOV", "AQAAAAIAAYagAAAAELGctLgrXDWB11k6xmT0qQvXjW+4yYsHvrrQ7NyraBiTcKSIZi+LJseGFfWJ4CrXTg==", null, false, 0, "", false, "tollov" },
                    { "d709b64a-2b0d-489a-b979-b264fbd2301a", 0, "737c0a55-5363-4a39-b8b1-deb250fb4eac", "bobswife@brainbox.com", true, false, null, "BOBSWIFE@BRAINBOX.COM", "BOBSWIFE", "AQAAAAIAAYagAAAAEI98nQmwB0Fy1cZSCa+kwcZoyXv2OzmxP7o0SuY8YmL7QMqwT9ftjzUmGKTK7FcWZw==", null, false, 0, "", false, "Bob's wife" },
                    { "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6", 0, "515799f3-ea0a-4f32-bda5-f82790d634d7", "bob@brainbox.com", true, false, null, "BOB@BRAINBOX.COM", "Bob", "AQAAAAIAAYagAAAAEK5y2Vps5wVgpPk0XrXdmdNJUVLxwYUZnDQ67Otx/4hfikJyL/JOaOFZ21kSsfkNyQ==", null, false, 1, "", false, "Bob" }
                });

            migrationBuilder.InsertData(
                table: "user_answers",
                columns: new[] { "answer_option_id", "user_id" },
                values: new object[,]
                {
                    { 9, "6db6382f-ca07-4d1e-9a75-4357b609f248" },
                    { 11, "6db6382f-ca07-4d1e-9a75-4357b609f248" },
                    { 5, "d709b64a-2b0d-489a-b979-b264fbd2301a" },
                    { 7, "d709b64a-2b0d-489a-b979-b264fbd2301a" },
                    { 1, "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" },
                    { 3, "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 9, "6db6382f-ca07-4d1e-9a75-4357b609f248" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 11, "6db6382f-ca07-4d1e-9a75-4357b609f248" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 5, "d709b64a-2b0d-489a-b979-b264fbd2301a" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 7, "d709b64a-2b0d-489a-b979-b264fbd2301a" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 1, "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" });

            migrationBuilder.DeleteData(
                table: "user_answers",
                keyColumns: new[] { "answer_option_id", "user_id" },
                keyValues: new object[] { 3, "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6" });

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "220420f1-3bd8-4e83-a731-766981c092ca");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "8389617c-5e8a-40b4-9131-ff6647aa6dde");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "6db6382f-ca07-4d1e-9a75-4357b609f248");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "d709b64a-2b0d-489a-b979-b264fbd2301a");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "feeba6b7-7f8d-4d8b-93ec-b7ff49552ea6");

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 2,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 4,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 6,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 8,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 9,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 11,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "questions",
                keyColumn: "id",
                keyValue: 12,
                column: "order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 22, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 21, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "719994b4-0509-4cc3-a089-c7591fb77468" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 20, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "b5d56b03-a018-436c-a0c3-ad0b13ac94d7" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 19, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "5a60c9b8-c68b-4779-9f93-b60ffa22c356" });

            migrationBuilder.UpdateData(
                table: "quizzes",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "creation_date", "user_id" },
                values: new object[] { new DateTime(2024, 3, 18, 8, 16, 22, 361, DateTimeKind.Utc).AddTicks(3915), "e0cbfecd-c1e2-4122-a802-30ca9eb9b2d8" });

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
        }
    }
}
