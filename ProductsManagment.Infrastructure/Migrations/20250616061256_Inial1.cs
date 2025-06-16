using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ServiceProviderId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ServiceProviderId",
                table: "Products",
                column: "ServiceProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ServiceProviderId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ServiceProviderId",
                table: "Products",
                column: "ServiceProviderId",
                principalTable: "Providers",
                principalColumn: "Id");
        }
    }
}
