using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Cabinet.Database.Migrations
{
    public partial class AddedStudentMarksTableAndRenamedTasksToHomeTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Photos_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HeadPhotoId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "HeadPhotoPhotoId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: true),
                    LessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTasks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeTasks_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    HomeTaskId = table.Column<int>(nullable: true),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMarks_HomeTasks_HomeTaskId",
                        column: x => x.HomeTaskId,
                        principalTable: "HomeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentMarks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HeadPhotoPhotoId",
                table: "Courses",
                column: "HeadPhotoPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTasks_LessonId",
                table: "HomeTasks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTasks_QuizId",
                table: "HomeTasks",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarks_HomeTaskId",
                table: "StudentMarks",
                column: "HomeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarks_StudentId",
                table: "StudentMarks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Photos_HeadPhotoPhotoId",
                table: "Courses",
                column: "HeadPhotoPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Photos_HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "StudentMarks");

            migrationBuilder.DropTable(
                name: "HomeTasks");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "HeadPhotoId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HeadPhotoId",
                table: "Courses",
                column: "HeadPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LessonId",
                table: "Tasks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_QuizId",
                table: "Tasks",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Photos_HeadPhotoId",
                table: "Courses",
                column: "HeadPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
