using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABSHybridX.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    BatchSize = table.Column<int>(type: "int", nullable: false),
                    IsBatchSizeFixed = table.Column<bool>(type: "bit", nullable: false),
                    MixTime = table.Column<int>(type: "int", nullable: false),
                    MixTemperature = table.Column<int>(type: "int", nullable: false),
                    LowerTemperatureDeviation = table.Column<int>(type: "int", nullable: false),
                    UpperTemperatureDeviation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
