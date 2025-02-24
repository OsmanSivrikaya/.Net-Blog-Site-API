using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class post_comment_entity_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "post_comments");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "post_comments");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "post_comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_visible",
                table: "post",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "post_comments");

            migrationBuilder.DropColumn(
                name: "is_visible",
                table: "post");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "post_comments",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "post_comments",
                type: "nvarchar(255)",
                nullable: true);
        }
    }
}
