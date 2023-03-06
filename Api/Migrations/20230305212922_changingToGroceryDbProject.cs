using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class changingToGroceryDbProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Group_GroupId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_MeasurementUnit_MeasurementUnitId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");

            migrationBuilder.DropIndex(
                name: "IX_Product_Code",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_GroupId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "MeasurementUnitId",
                table: "Product",
                newName: "MergedProductId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "String");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Product",
                newName: "ImgUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Product_MeasurementUnitId",
                table: "Product",
                newName: "IX_Product_MergedProductId");

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MergedProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergedProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsWholeSale = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    String = table.Column<string>(type: "text", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Market_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    String = table.Column<string>(type: "text", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartedById = table.Column<Guid>(type: "uuid", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MarketId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingEvent_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingEvent_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingEvent_User_StartedById",
                        column: x => x.StartedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShoppingEventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grabbed = table.Column<bool>(type: "boolean", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    FaceValue = table.Column<double>(type: "double precision", nullable: false),
                    MinWholesaleQuantity = table.Column<int>(type: "integer", nullable: false),
                    WholesaleFaceValue = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingList_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingList_ShoppingEvent_ShoppingEventId",
                        column: x => x.ShoppingEventId,
                        principalTable: "ShoppingEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BarCode",
                table: "Product",
                column: "BarCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Family_OwnerId",
                table: "Family",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_LocationId",
                table: "Market",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingEvent_FamilyId",
                table: "ShoppingEvent",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingEvent_MarketId",
                table: "ShoppingEvent",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingEvent_StartedById",
                table: "ShoppingEvent",
                column: "StartedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ProductId",
                table: "ShoppingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ShoppingEventId",
                table: "ShoppingList",
                column: "ShoppingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FamilyId",
                table: "User",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_MergedProduct_MergedProductId",
                table: "Product",
                column: "MergedProductId",
                principalTable: "MergedProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Family_User_OwnerId",
                table: "Family",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_MergedProduct_MergedProductId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Family_User_OwnerId",
                table: "Family");

            migrationBuilder.DropTable(
                name: "MergedProduct");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "ShoppingEvent");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropIndex(
                name: "IX_Product_BarCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "String",
                table: "Product",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MergedProductId",
                table: "Product",
                newName: "MeasurementUnitId");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Product",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Product_MergedProductId",
                table: "Product",
                newName: "IX_Product_MeasurementUnitId");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "Product",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                table: "Product",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_GroupId",
                table: "Product",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Group_GroupId",
                table: "Product",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_MeasurementUnit_MeasurementUnitId",
                table: "Product",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
