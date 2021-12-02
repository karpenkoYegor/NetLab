using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityDb.Migrations
{
    public partial class TestOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_University_CityID",
                table: "University",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_University_City_CityID",
                table: "University",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_University_City_CityID",
                table: "University");

            migrationBuilder.DropIndex(
                name: "IX_University_CityID",
                table: "University");
        }
    }
}
