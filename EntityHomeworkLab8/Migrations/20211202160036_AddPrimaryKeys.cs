using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class AddPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_University_UniversityID",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_UniversityID",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "Group",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_University_GroupID",
                table: "Group",
                column: "GroupID",
                principalTable: "University",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_University_GroupID",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "Group",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UniversityID",
                table: "Group",
                column: "UniversityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_University_UniversityID",
                table: "Group",
                column: "UniversityID",
                principalTable: "University",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
