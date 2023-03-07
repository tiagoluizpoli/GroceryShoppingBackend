using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListSeparatedFromShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Product_ProductId",
                table: "ShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_ShoppingEvent_ShoppingEventId",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_ProductId",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_ShoppingEventId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "FaceValue",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "MinWholesaleQuantity",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "ShoppingEventId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "WholesaleFaceValue",
                table: "ShoppingList");

            migrationBuilder.RenameColumn(
                name: "Grabbed",
                table: "ShoppingList",
                newName: "Enabled");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShoppingList",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingList",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShoppingEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FaceValue = table.Column<double>(type: "double precision", nullable: false),
                    MinWholesaleQuantity = table.Column<int>(type: "integer", nullable: false),
                    WholesaleFaceValue = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_ShoppingEvent_ShoppingEventId",
                        column: x => x.ShoppingEventId,
                        principalTable: "ShoppingEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ListId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Grabbed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_ShoppingList_ListId",
                        column: x => x.ListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ProductId",
                table: "ShoppingCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ShoppingEventId",
                table: "ShoppingCart",
                column: "ShoppingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ListId",
                table: "ShoppingListItems",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingList");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "ShoppingList",
                newName: "Grabbed");

            migrationBuilder.AddColumn<double>(
                name: "FaceValue",
                table: "ShoppingList",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinWholesaleQuantity",
                table: "ShoppingList",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ShoppingList",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingList",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingEventId",
                table: "ShoppingList",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "WholesaleFaceValue",
                table: "ShoppingList",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ProductId",
                table: "ShoppingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ShoppingEventId",
                table: "ShoppingList",
                column: "ShoppingEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Product_ProductId",
                table: "ShoppingList",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_ShoppingEvent_ShoppingEventId",
                table: "ShoppingList",
                column: "ShoppingEventId",
                principalTable: "ShoppingEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
