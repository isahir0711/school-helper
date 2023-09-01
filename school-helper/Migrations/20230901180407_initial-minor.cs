using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_helper.Migrations
{
    public partial class initialminor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "ClassIs",
                table: "ClassSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "ClassSchedules",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ClassIs",
                table: "ClassSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedules_Classes_ClassId",
                table: "ClassSchedules",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}
