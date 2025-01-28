using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class post_type_add_column_is_deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_comments_post_post_id",
                table: "blog_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_likes_post_post_id",
                table: "blog_likes");

            migrationBuilder.DropForeignKey(
                name: "FK_post_blog_types_type_id",
                table: "post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog_types",
                table: "blog_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog_likes",
                table: "blog_likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blog_comments",
                table: "blog_comments");

            migrationBuilder.RenameTable(
                name: "blog_types",
                newName: "post_types");

            migrationBuilder.RenameTable(
                name: "blog_likes",
                newName: "post_likes");

            migrationBuilder.RenameTable(
                name: "blog_comments",
                newName: "post_comments");

            migrationBuilder.RenameIndex(
                name: "IX_blog_likes_post_id",
                table: "post_likes",
                newName: "IX_post_likes_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_comments_post_id",
                table: "post_comments",
                newName: "IX_post_comments_post_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "post_types",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "post_types",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_types",
                table: "post_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_likes",
                table: "post_likes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_comments",
                table: "post_comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_post_types_type_id",
                table: "post",
                column: "type_id",
                principalTable: "post_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comments_post_post_id",
                table: "post_comments",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_likes_post_post_id",
                table: "post_likes",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_post_types_type_id",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comments_post_post_id",
                table: "post_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_post_likes_post_post_id",
                table: "post_likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_types",
                table: "post_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_likes",
                table: "post_likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_comments",
                table: "post_comments");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "post_types");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "post_types");

            migrationBuilder.RenameTable(
                name: "post_types",
                newName: "blog_types");

            migrationBuilder.RenameTable(
                name: "post_likes",
                newName: "blog_likes");

            migrationBuilder.RenameTable(
                name: "post_comments",
                newName: "blog_comments");

            migrationBuilder.RenameIndex(
                name: "IX_post_likes_post_id",
                table: "blog_likes",
                newName: "IX_blog_likes_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_post_comments_post_id",
                table: "blog_comments",
                newName: "IX_blog_comments_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog_types",
                table: "blog_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog_likes",
                table: "blog_likes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blog_comments",
                table: "blog_comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_comments_post_post_id",
                table: "blog_comments",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_likes_post_post_id",
                table: "blog_likes",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_blog_types_type_id",
                table: "post",
                column: "type_id",
                principalTable: "blog_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
