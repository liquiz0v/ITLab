using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Landing.MVC.Migrations
{
    public partial class remove_error_with_short_newsvirtualtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortNews",
                columns: table => new
                {
                    CommentsCount = table.Column<int>(type: "int", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
