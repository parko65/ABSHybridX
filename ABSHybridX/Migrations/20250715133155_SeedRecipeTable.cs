using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABSHybridX.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "BatchSize", "CreatedDate", "IsBatchSizeFixed", "IsValid", "LowerTemperatureDeviation", "MixTemperature", "MixTime", "Name", "Title", "UpperTemperatureDeviation", "VersionNumber" },
                values: new object[] { 1, 3000, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 15, 130, 25, "120A103Z", "WARM AC 32 DENSE BASE 40/60 (HYBRID)", 40, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);
        }
    }
}
