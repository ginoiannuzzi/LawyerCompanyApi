using Microsoft.EntityFrameworkCore.Migrations;

namespace Afte.Database.Migrations
{
    public partial class DeleteOnCascadeComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comment_UsuarioId",
                table: "Comment",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Usuario_UsuarioId",
                table: "Comment",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Usuario_UsuarioId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UsuarioId",
                table: "Comment");
        }
    }
}
