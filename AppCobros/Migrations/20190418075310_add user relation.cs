using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCobros.Migrations
{
    public partial class adduserrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "PaymentDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_IdUsuario",
                table: "PaymentDetails",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_users_IdUsuario",
                table: "PaymentDetails",
                column: "IdUsuario",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_users_IdUsuario",
                table: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_IdUsuario",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "PaymentDetails");
        }
    }
}
