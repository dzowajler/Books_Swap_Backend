using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbConnection.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserBooksTableNameToBookOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_Users_UserId",
                table: "UsersBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks");

            migrationBuilder.RenameTable(
                name: "UsersBooks",
                newName: "BookOwners");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBooks_UserId",
                table: "BookOwners",
                newName: "IX_BookOwners_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBooks_BookId",
                table: "BookOwners",
                newName: "IX_BookOwners_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOwners",
                table: "BookOwners",
                column: "UsersBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOwners_Books_BookId",
                table: "BookOwners",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookOwners_Users_UserId",
                table: "BookOwners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOwners_Books_BookId",
                table: "BookOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_BookOwners_Users_UserId",
                table: "BookOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOwners",
                table: "BookOwners");

            migrationBuilder.RenameTable(
                name: "BookOwners",
                newName: "UsersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BookOwners_UserId",
                table: "UsersBooks",
                newName: "IX_UsersBooks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookOwners_BookId",
                table: "UsersBooks",
                newName: "IX_UsersBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks",
                column: "UsersBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_Users_UserId",
                table: "UsersBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
