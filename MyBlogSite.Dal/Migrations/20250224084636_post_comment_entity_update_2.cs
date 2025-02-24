using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class post_comment_entity_update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "post_comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_post_comments_user_id",
                table: "post_comments",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_comments_users_user_id",
                table: "post_comments",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_comments_users_user_id",
                table: "post_comments");

            migrationBuilder.DropIndex(
                name: "IX_post_comments_user_id",
                table: "post_comments");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "post_comments");
        }
    }
}
