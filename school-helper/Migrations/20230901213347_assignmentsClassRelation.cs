using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_helper.Migrations
{
    public partial class assignmentsClassRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Assignments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Classes_ClassId",
                table: "Assignments",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Classes_ClassId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Assignments");
        }
    }
}
