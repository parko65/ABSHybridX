using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABSHybridX.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialNumberToAggregate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Materialnumber",
                table: "Aggregates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materialnumber",
                table: "Aggregates");
        }
    }
}
