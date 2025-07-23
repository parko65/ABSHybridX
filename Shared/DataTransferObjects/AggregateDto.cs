namespace Shared.DataTransferObjects;
public record AggregateDto
{
    public int Id { get; init; }
    public int Materialnumber { get; init; }
    public string? Name { get; init; }
    public int? HotBinId { get; init; }
}
