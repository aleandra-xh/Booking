using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyAmenityDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAmenities_Properties_PropertyId",
                table: "PropertyAmenities");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAmenities_Properties_PropertyId",
                table: "PropertyAmenities",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAmenities_Properties_PropertyId",
                table: "PropertyAmenities");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAmenities_Properties_PropertyId",
                table: "PropertyAmenities",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
