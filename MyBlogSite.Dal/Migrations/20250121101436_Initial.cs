using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type_name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    slag = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    blog_name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    slag = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    blog_description = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    slag = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    is_executive = table.Column<bool>(type: "bit", nullable: false),
                    blog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_blogs_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    blog_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    slag = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_blog_types_type_id",
                        column: x => x.type_id,
                        principalTable: "blog_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_blogs_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blog_comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parent_comment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_blog_comments_post_post_id",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blog_likes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_blog_likes_post_post_id",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_tags", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_tags_post_post_id",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_comments_post_id",
                table: "blog_comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_likes_post_id",
                table: "blog_likes",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_blog_id",
                table: "post",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_type_id",
                table: "post",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_user_id",
                table: "post",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_tags_post_id",
                table: "post_tags",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_tags_tag_id",
                table: "post_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_blog_id",
                table: "users",
                column: "blog_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_comments");

            migrationBuilder.DropTable(
                name: "blog_likes");

            migrationBuilder.DropTable(
                name: "post_tags");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "blog_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "blogs");
        }
    }
}
