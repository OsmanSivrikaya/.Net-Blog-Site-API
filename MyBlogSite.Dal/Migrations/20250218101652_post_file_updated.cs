using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class post_file_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_approved",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "slag",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "is_visible",
                table: "post_tags");

            migrationBuilder.AddColumn<int>(
                name: "tag_status",
                table: "tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "file_directory",
                table: "post_files",
                type: "nvarchar(4000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tag_status",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "file_directory",
                table: "post_files");

            migrationBuilder.AddColumn<bool>(
                name: "is_approved",
                table: "tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "slag",
                table: "tags",
                type: "nvarchar(4000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_visible",
                table: "post_tags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
