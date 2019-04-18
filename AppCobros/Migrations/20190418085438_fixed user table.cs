using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCobros.Migrations
{
    public partial class fixedusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_users_IdUsuario",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "PaymentDetails",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_IdUsuario",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "genero",
                table: "users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_users_UsuarioId",
                table: "PaymentDetails",
                column: "UsuarioId",
                principalTable: "users",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_users_UsuarioId",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "genero",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "PaymentDetails",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_UsuarioId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_users_IdUsuario",
                table: "PaymentDetails",
                column: "IdUsuario",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
