using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_comments_blogs_BlogId",
                table: "blog_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_likes_blogs_BlogId",
                table: "blog_likes");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_properties_blogs_BlogId",
                table: "blog_properties");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "users",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "users",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tickets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "tickets",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "TicketName",
                table: "tickets",
                newName: "ticket_name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tickets",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "blogs",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "blogs",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blogs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "blogs",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "blogs",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "blogs",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "blogs",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_UserId",
                table: "blogs",
                newName: "IX_blogs_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blog_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "blog_types",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "blog_types",
                newName: "type_name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "blog_types",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blog_properties",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "blog_properties",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "NumberOfViews",
                table: "blog_properties",
                newName: "number_of_views");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "blog_properties",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blog_properties",
                newName: "blog_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_properties_BlogId",
                table: "blog_properties",
                newName: "IX_blog_properties_blog_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "blog_likes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blog_likes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "blog_likes",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "blog_likes",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blog_likes",
                newName: "blog_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_likes_BlogId",
                table: "blog_likes",
                newName: "IX_blog_likes_blog_id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "blog_comments",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "blog_comments",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blog_comments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "blog_comments",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "RepliedCommentId",
                table: "blog_comments",
                newName: "replied_comment_id");

            migrationBuilder.RenameColumn(
                name: "IsItApproved",
                table: "blog_comments",
                newName: "is_it_approved");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "blog_comments",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "blog_comments",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blog_comments",
                newName: "blog_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_comments_BlogId",
                table: "blog_comments",
                newName: "IX_blog_comments_blog_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "tickets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ticket_name",
                table: "tickets",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "blogs",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "text",
                table: "blogs",
                type: "nvarchar(10000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "blogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "blog_types",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "type_name",
                table: "blog_types",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "blog_properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "blog_likes",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "blog_likes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "text",
                table: "blog_comments",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "blog_comments",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_date",
                table: "blog_comments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "blog_comments",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_comments_blogs_blog_id",
                table: "blog_comments",
                column: "blog_id",
                principalTable: "blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_likes_blogs_blog_id",
                table: "blog_likes",
                column: "blog_id",
                principalTable: "blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_properties_blogs_blog_id",
                table: "blog_properties",
                column: "blog_id",
                principalTable: "blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_user_id",
                table: "blogs",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_comments_blogs_blog_id",
                table: "blog_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_likes_blogs_blog_id",
                table: "blog_likes");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_properties_blogs_blog_id",
                table: "blog_properties");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_user_id",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "users",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "tickets",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "ticket_name",
                table: "tickets",
                newName: "TicketName");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "tickets",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "blogs",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blogs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "blogs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "blogs",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "blogs",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "blogs",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_user_id",
                table: "blogs",
                newName: "IX_blogs_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blog_types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "blog_types",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "type_name",
                table: "blog_types",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "blog_types",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blog_properties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "blog_properties",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "number_of_views",
                table: "blog_properties",
                newName: "NumberOfViews");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "blog_properties",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "blog_id",
                table: "blog_properties",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_blog_properties_blog_id",
                table: "blog_properties",
                newName: "IX_blog_properties_BlogId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "blog_likes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blog_likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "blog_likes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "blog_likes",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "blog_id",
                table: "blog_likes",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_blog_likes_blog_id",
                table: "blog_likes",
                newName: "IX_blog_likes_BlogId");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "blog_comments",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "blog_comments",
                newName: "EMail");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blog_comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "blog_comments",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "replied_comment_id",
                table: "blog_comments",
                newName: "RepliedCommentId");

            migrationBuilder.RenameColumn(
                name: "is_it_approved",
                table: "blog_comments",
                newName: "IsItApproved");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "blog_comments",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "blog_comments",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "blog_id",
                table: "blog_comments",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_blog_comments_blog_id",
                table: "blog_comments",
                newName: "IX_blog_comments_BlogId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketName",
                table: "tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "blog_types",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "blog_types",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "blog_properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "blog_likes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "blog_likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "blog_comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "blog_comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "blog_comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "blog_comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_comments_blogs_BlogId",
                table: "blog_comments",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_likes_blogs_BlogId",
                table: "blog_likes",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_properties_blogs_BlogId",
                table: "blog_properties",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
