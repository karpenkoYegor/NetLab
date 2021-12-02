using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class DropColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversityTeacher",
                table: "UniversityTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "UniversityID",
                table: "UniversityTeacher");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "UniversityTeacher");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "StudentSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversityID",
                table: "UniversityTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "UniversityTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversityTeacher",
                table: "UniversityTeacher",
                column: "UniversityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                column: "SubjectID");
        }
    }
}
