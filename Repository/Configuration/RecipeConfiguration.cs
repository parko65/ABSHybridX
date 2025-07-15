using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasData
            (
            new Recipe
            {
                Id = 1,
                Name = "120A103Z",
                Title = "WARM AC 32 DENSE BASE 40/60 (HYBRID)",
                VersionNumber = 7,
                CreatedDate = new DateTime(2023, 10, 1),
                IsValid = true,
                BatchSize = 3000,
                IsBatchSizeFixed = true,
                MixTime = 25,
                MixTemperature = 130,
                LowerTemperatureDeviation = 15,
                UpperTemperatureDeviation = 40
            });
    }
}
