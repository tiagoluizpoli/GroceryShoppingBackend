using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class settingDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_MeasurementUnitModel_MeasurementUnitId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductGroup_GroupId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGroup",
                table: "ProductGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnitModel",
                table: "MeasurementUnitModel");

            migrationBuilder.RenameTable(
                name: "ProductGroup",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "MeasurementUnitModel",
                newName: "MeasurementUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnit",
                table: "MeasurementUnit",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Group_GroupId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_MeasurementUnit_MeasurementUnitId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnit",
                table: "MeasurementUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "MeasurementUnit",
                newName: "MeasurementUnitModel");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "ProductGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnitModel",
                table: "MeasurementUnitModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGroup",
                table: "ProductGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_MeasurementUnitModel_MeasurementUnitId",
                table: "Product",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductGroup_GroupId",
                table: "Product",
                column: "GroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
