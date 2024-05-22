using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOrderItemClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
