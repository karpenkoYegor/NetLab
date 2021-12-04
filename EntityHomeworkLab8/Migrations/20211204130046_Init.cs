using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    UniversityID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UniversityID);
                    table.ForeignKey(
                        name: "FK_University_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Group_University_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "University",
                        principalColumn: "UniversityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityTeacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: false),
                    Wage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityTeacher", x => new { x.TeacherID, x.UniversityID });
                    table.ForeignKey(
                        name: "FK_UniversityTeacher_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityTeacher_University_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "University",
                        principalColumn: "UniversityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bursary = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_UniversityID",
                table: "Group",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CityID",
                table: "Student",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupID",
                table: "Student",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectID",
                table: "StudentSubject",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectID",
                table: "Teacher",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_University_CityID",
                table: "University",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeacher_UniversityID",
                table: "UniversityTeacher",
                column: "UniversityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "UniversityTeacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
