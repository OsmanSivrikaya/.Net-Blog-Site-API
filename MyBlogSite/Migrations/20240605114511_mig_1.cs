using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_blogs_BlogId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_User_UserId",
                table: "blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_BlogId",
                table: "tickets",
                newName: "IX_tickets_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "blog_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_types", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_blogs_BlogId",
                table: "tickets",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_blogs_BlogId",
                table: "tickets");

            migrationBuilder.DropTable(
                name: "blog_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_tickets_BlogId",
                table: "Ticket",
                newName: "IX_Ticket_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_blogs_BlogId",
                table: "Ticket",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_User_UserId",
                table: "blogs",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
