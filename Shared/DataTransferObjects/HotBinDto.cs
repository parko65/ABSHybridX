namespace Shared.DataTransferObjects;
public record HotBinDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public AggregateDto? Aggregate { get; init; }
}
