using Service.Contracts;
using Shared.DataTransferObjects;

namespace ABSHybridX.Components.Material;

public partial class MaterialDefinitions
{
    private readonly IServiceManager _service;

    public MaterialDefinitions(IServiceManager service)
    {
        _service = service;
    }

    public List<AggregateDto> Aggregates = new();
    private AggregateInputModel _aggregateInput = new();

    private sealed class AggregateInputModel
    {
        public string? Name { get; set; }
        public int? HotBinId { get; set; }
    }
}


