using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class user_and_blog_table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_executive",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "founder_user_id",
                table: "blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "founder_user_id",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "blogs");

            migrationBuilder.AddColumn<bool>(
                name: "is_executive",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
