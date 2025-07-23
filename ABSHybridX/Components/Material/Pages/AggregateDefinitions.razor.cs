using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace ABSHybridX.Components.Material.Pages;

public partial class AggregateDefinitions
{
    private readonly IServiceManager _service;

    public AggregateDefinitions(IServiceManager service)
    {
        _service = service;
    }

    public IQueryable<AggregateDto>? Aggregates;

    private AggregateInputModel _aggregateInput = new();

    private EditContext? _editContext;

    private bool formInvalid = true;
    private AggregateDto? SelectedAggregate { get; set; }

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_aggregateInput);
        _editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        // Handle field changes if needed
        // For example, you can validate the input or update the UI
        formInvalid = !_editContext!.Validate();
        StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadAggregatesAsync();
    }

    private async Task LoadAggregatesAsync()
    {
        var aggregates = await _service.AggregateService.GetAggregatesAsync(trackChanges: false);
        Aggregates = aggregates.AsQueryable();
    }

    private async Task CreateAggregateAsync()
    {
        _editContext!.Validate();

        //var result = int.TryParse(_aggregateInput.MaterialNumber, out int MaterialNumber);

        //var aggregateToCreate = new AggregateForCreationDto
        //{
        //    Materialnumber = MaterialNumber,
        //    Name = _aggregateInput.Name
        //};

        //var createdAggregate = await _service.AggregateService.CreateAggregateAsync(aggregateToCreate, trackChanges: false);

        //await LoadAggregatesAsync();
    }

    private void CreateNewDto()
    {
        _editContext = new EditContext(_aggregateInput);
    }

    private void HandleRowClick(FluentDataGridRow<AggregateDto> agg)
    {
        SelectedAggregate = agg.Item;        
    }

    private string? GetRowClass(AggregateDto agg)
    {
        return SelectedAggregate == agg ? "selected-row" : null;
    }

    private sealed class AggregateInputModel
    {
        [Required(ErrorMessage = "Material number is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Material number must be a positive integer.")]
        public string MaterialNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(10, ErrorMessage = "Name cannot exceed 10 characters.")]
        public string Name { get; set; } = string.Empty;
        public int? HotBinId { get; set; }
    }
}