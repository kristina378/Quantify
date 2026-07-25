using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quantify.Migrations
{
    /// <inheritdoc />
    public partial class AddAbilityToDeleteAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DeletedTime", "IsDeleted", "PasswordHash" },
                values: new object[] { null, false, "AQAAAAIAAYagAAAAELvKjKrHfKo3B2t//Wb95jR3OKHcDxrfon5G4CseepUMijXSu0JOEV9XKa4VsNzt8Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMK7VGGCQbmDd222qUrH62yJsDBCkyPEByhp0A3I2vpDHL/MiogUB7Y+6VUx0IcQxA==");
        }
    }
}
