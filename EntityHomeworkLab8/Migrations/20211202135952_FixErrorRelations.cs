using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class FixErrorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_StudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "StudentStudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentSubjectStudentID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentSubjectSubjectID",
                table: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectID",
                table: "StudentSubject",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Student_StudentID",
                table: "StudentSubject",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subject_SubjectID",
                table: "StudentSubject",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Student_StudentID",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subject_SubjectID",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_SubjectID",
                table: "StudentSubject");

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
                name: "IX_Subject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "StudentStudentSubject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_StudentSubject_StudentSubjectStudentID_StudentSubjectSubjectID",
                table: "Subject",
                columns: new[] { "StudentSubjectStudentID", "StudentSubjectSubjectID" },
                principalTable: "StudentSubject",
                principalColumns: new[] { "StudentID", "SubjectID" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
