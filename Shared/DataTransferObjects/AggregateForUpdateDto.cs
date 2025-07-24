namespace Shared.DataTransferObjects;
public record AggregateForUpdateDto
{
    public int MaterialNumber { get; init; }
    public string? Name { get; init; }
    public int? HotBinId { get; init; }
}
