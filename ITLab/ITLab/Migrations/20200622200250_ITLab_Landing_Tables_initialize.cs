using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITLab.Landing.MVC.Migrations
{
    public partial class ITLab_Landing_Tables_initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackStatuses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statuses = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackStatuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    TimeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HeadPhoto = table.Column<string>(nullable: true),
                    ViewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShortNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    TimeDate = table.Column<DateTime>(nullable: false),
                    HeadPhoto = table.Column<string>(nullable: true),
                    CommentsCount = table.Column<int>(nullable: false),
                    ViewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Question = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    FeedbackStatus = table.Column<int>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK__Feedback__Feedba__4316F928",
                        column: x => x.FeedbackStatus,
                        principalTable: "FeedbackStatuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.id);
                    table.ForeignKey(
                        name: "FK__Photos__NewsId__398D8EEE",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.id);
                    table.ForeignKey(
                        name: "FK__Videos__NewsId__3D5E1FD2",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(nullable: true),
                    TimeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CommentatorId = table.Column<int>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Comments__Commen__49C3F6B7",
                        column: x => x.CommentatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__NewsId__4AB81AF0",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentatorId",
                table: "Comments",
                column: "CommentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackStatus",
                table: "Feedback",
                column: "FeedbackStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_NewsId",
                table: "Photos",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_NewsId",
                table: "Videos",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "ShortNews");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FeedbackStatuses");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
