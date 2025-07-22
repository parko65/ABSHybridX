using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABSHybridX.Migrations
{
    /// <inheritdoc />
    public partial class AddHotBinsAndAggregates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotBins",
                columns: table => new
                {
                    HotBinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBins", x => x.HotBinId);
                });

            migrationBuilder.CreateTable(
                name: "Aggregates",
                columns: table => new
                {
                    AggregateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotBinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggregates", x => x.AggregateId);
                    table.ForeignKey(
                        name: "FK_Aggregates_HotBins_HotBinId",
                        column: x => x.HotBinId,
                        principalTable: "HotBins",
                        principalColumn: "HotBinId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aggregates_HotBinId",
                table: "Aggregates",
                column: "HotBinId",
                unique: true,
                filter: "[HotBinId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aggregates");

            migrationBuilder.DropTable(
                name: "HotBins");
        }
    }
}
