using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigSalonandStylistRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stylists_Salons_SalonId",
                table: "Stylists");

            migrationBuilder.AddForeignKey(
                name: "FK_Stylists_Salons_SalonId",
                table: "Stylists",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stylists_Salons_SalonId",
                table: "Stylists");

            migrationBuilder.AddForeignKey(
                name: "FK_Stylists_Salons_SalonId",
                table: "Stylists",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
