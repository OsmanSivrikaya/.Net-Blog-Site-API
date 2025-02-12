using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogSite.Dal.Migrations
{
    /// <inheritdoc />
    public partial class post_file_table_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMainFile",
                table: "post_files",
                newName: "is_main_file");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "post_files",
                newName: "file_url");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "post_files",
                newName: "file_type");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "post_files",
                newName: "file_name");

            migrationBuilder.AlterColumn<string>(
                name: "file_url",
                table: "post_files",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "file_type",
                table: "post_files",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "post_files",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_post_files_post_id",
                table: "post_files",
                column: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_files_post_post_id",
                table: "post_files",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_files_post_post_id",
                table: "post_files");

            migrationBuilder.DropIndex(
                name: "IX_post_files_post_id",
                table: "post_files");

            migrationBuilder.RenameColumn(
                name: "is_main_file",
                table: "post_files",
                newName: "IsMainFile");

            migrationBuilder.RenameColumn(
                name: "file_url",
                table: "post_files",
                newName: "FileUrl");

            migrationBuilder.RenameColumn(
                name: "file_type",
                table: "post_files",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "post_files",
                newName: "FileName");

            migrationBuilder.AlterColumn<string>(
                name: "FileUrl",
                table: "post_files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "post_files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "post_files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");
        }
    }
}
