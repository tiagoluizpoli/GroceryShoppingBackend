using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class familyMustBeNullableTake4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Family_OwnerId",
                table: "Family");

            migrationBuilder.CreateIndex(
                name: "IX_Family_OwnerId",
                table: "Family",
                column: "OwnerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Family_OwnerId",
                table: "Family");

            migrationBuilder.CreateIndex(
                name: "IX_Family_OwnerId",
                table: "Family",
                column: "OwnerId");
        }
    }
}
