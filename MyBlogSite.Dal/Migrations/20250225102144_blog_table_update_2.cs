using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class blog_table_update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "founder_user_id",
                table: "blogs",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "founder_user_id",
                table: "blogs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);
        }
    }
}
