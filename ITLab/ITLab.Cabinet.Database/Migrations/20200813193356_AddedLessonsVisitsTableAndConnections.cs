using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Cabinet.Database.Migrations
{
    public partial class AddedLessonsVisitsTableAndConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonsVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    LessonId = table.Column<int>(nullable: true),
                    Visited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonsVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonsVisits_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonsVisits_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonsVisits_LessonId",
                table: "LessonsVisits",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonsVisits_StudentId",
                table: "LessonsVisits",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonsVisits");
        }
    }
}
