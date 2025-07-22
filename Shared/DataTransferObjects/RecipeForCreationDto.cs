namespace Shared.DataTransferObjects;

public record RecipeForCreationDto(
    int Id,
    string Name,
    string Title,    
    int BatchSize,
    bool IsBatchSizeFixed,
    int MixTime,
    int MixTemperature,
    int LowerTemperatureDeviation,
    int UpperTemperatureDeviation    
    );