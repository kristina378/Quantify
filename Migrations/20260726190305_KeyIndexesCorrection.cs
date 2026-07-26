using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quantify.Migrations
{
    /// <inheritdoc />
    public partial class KeyIndexesCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topic",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELUwYP0PHpfaQveyTooyWNDyMfhFmAeeERYB13DdilrU/MnssvTuyaahVQqzc/F3GA==");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_Name",
                table: "Topic",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topic_Name",
                table: "Topic");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topic",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELvKjKrHfKo3B2t//Wb95jR3OKHcDxrfon5G4CseepUMijXSu0JOEV9XKa4VsNzt8Q==");
        }
    }
}
