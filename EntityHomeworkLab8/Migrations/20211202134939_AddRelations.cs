using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Teacher",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjectStudentID",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjectSubjectID",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentStudentSubject",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    StudentSubjectStudentID = table.Column<int>(type: "int", nullable: false),
                    StudentSubjectSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentSubject", x => new { x.StudentID, x.StudentSubjectStudentID, x.StudentSubjectSubjectID });
                    table.ForeignKey(
                        name: "FK_StudentStudentSubject_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentSubject_StudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                        columns: x => new { x.StudentSubjectStudentID, x.StudentSubjectSubjectID },
                        principalTable: "StudentSubject",
                        principalColumns: new[] { "StudentID", "SubjectID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeacher_UniversityID",
                table: "UniversityTeacher",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectID",
                table: "Teacher",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_CityID",
                table: "Student",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupID",
                table: "Student",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UniversityID",
                table: "Group",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "StudentStudentSubject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Group_University_UniversityID",
                table: "Group",
                column: "UniversityID",
                principalTable: "University",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_City_CityID",
                table: "Student",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupID",
                table: "Student",
                column: "GroupID",
                principalTable: "Group",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_StudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" },
                principalTable: "StudentSubject",
                principalColumns: new[] { "StudentID", "SubjectID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subject_SubjectID",
                table: "Teacher",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTeacher_Teacher_TeacherID",
                table: "UniversityTeacher",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTeacher_University_UniversityID",
                table: "UniversityTeacher",
                column: "UniversityID",
                principalTable: "University",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_University_UniversityID",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_City_CityID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_StudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subject_SubjectID",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTeacher_Teacher_TeacherID",
                table: "UniversityTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTeacher_University_UniversityID",
                table: "UniversityTeacher");

            migrationBuilder.DropTable(
                name: "StudentStudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_UniversityTeacher_UniversityID",
                table: "UniversityTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_SubjectID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_CityID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GroupID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Group_UniversityID",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "StudentSubjectStudentID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Teacher",
                newName: "Number");
        }
    }
}
