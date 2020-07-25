using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Cabinet.Database.Migrations
{
    public partial class AddCoursesPhotosAndLessonsDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LessonDateFrom",
                table: "Lessons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LessonDateTo",
                table: "Lessons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HeadPhotoId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CourseId",
                table: "Photos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HeadPhotoId",
                table: "Courses",
                column: "HeadPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Photos_HeadPhotoId",
                table: "Courses",
                column: "HeadPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Photos_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Courses_CourseId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CourseId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "LessonDateFrom",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonDateTo",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "HeadPhotoId",
                table: "Courses");
        }
    }
}
