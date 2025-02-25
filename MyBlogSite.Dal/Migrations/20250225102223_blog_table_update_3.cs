using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class blog_table_update_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "founder_user_id",
                table: "blogs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "founder_user_id",
                table: "blogs",
                type: "nvarchar(4000)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
