using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "String",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "String",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "String",
                table: "Family");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Market",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Family",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Family");

            migrationBuilder.AddColumn<string>(
                name: "String",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "String",
                table: "Market",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "String",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
