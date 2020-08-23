using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Cabinet.Database.Migrations
{
    public partial class UpdatedCourseColumnHeadPhotoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Photos_HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HeadPhotoPhotoId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "HeadPhotoId",
                table: "Courses",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Photos_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HeadPhotoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HeadPhotoId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "HeadPhotoPhotoId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HeadPhotoPhotoId",
                table: "Courses",
                column: "HeadPhotoPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Photos_HeadPhotoPhotoId",
                table: "Courses",
                column: "HeadPhotoPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
