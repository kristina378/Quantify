using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quantify.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PasswordHash", "Permission", "PhoneNumber", "Surname" },
                values: new object[] { 1L, "Admin", "kristinadubiaha07@gmail.com", "admin", "AQAAAAIAAYagAAAAEBqodLtc/3OaaYL66QgSnrVeCERzGJUzP0YuXTCs5JKrgvbXm4bFKp7VQgJeAL1jRA==", 1, "12345678", "anonymous" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
