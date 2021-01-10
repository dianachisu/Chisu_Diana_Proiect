using Microsoft.EntityFrameworkCore.Migrations;

namespace Chisu_Diana_Proiect.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Plant",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plant",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "NameID",
                table: "Description",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Description_NameID",
                table: "Description",
                column: "NameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Plant_NameID",
                table: "Description",
                column: "NameID",
                principalTable: "Plant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_Plant_NameID",
                table: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Description_NameID",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "NameID",
                table: "Description");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Plant",
                type: "decimal(18,2)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Plant",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
