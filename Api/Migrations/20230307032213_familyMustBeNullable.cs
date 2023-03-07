using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class familyMustBeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Family_FamilyId",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Family_FamilyId",
                table: "User",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Family_FamilyId",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Family_FamilyId",
                table: "User",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
