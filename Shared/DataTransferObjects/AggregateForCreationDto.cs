﻿namespace Shared.DataTransferObjects;
public record AggregateForCreationDto
{
    public int MaterialNumber { get; init; }
    public string? Name { get; init; }
    public int? HotBinId { get; init; }
}
