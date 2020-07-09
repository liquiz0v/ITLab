using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Cabinet.Database.Migrations
{
    public partial class AddAvatarPhotoFieldToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPhoto",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPhoto",
                table: "Students");
        }
    }
}
