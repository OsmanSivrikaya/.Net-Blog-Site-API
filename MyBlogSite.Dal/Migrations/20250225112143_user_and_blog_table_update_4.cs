using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class user_and_blog_table_update_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_banned",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_banned",
                table: "blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_banned",
                table: "users");

            migrationBuilder.DropColumn(
                name: "is_banned",
                table: "blogs");
        }
    }
}
