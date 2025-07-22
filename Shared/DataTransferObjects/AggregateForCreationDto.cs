namespace Shared.DataTransferObjects;
public record AggregateForCreationDto
{    
    public string? Name { get; init; }
    public int? HotBinId { get; init; }
}
