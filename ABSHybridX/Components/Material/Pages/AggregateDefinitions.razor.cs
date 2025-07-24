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
    private bool editMode = false;

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

    private async Task SaveAggregateAsync()
    {
        _editContext!.Validate();

        // Check if we have a new aggregate or an existing one
        if (SelectedAggregate is not null)
        {
            // Update existing aggregate
            var updatedAggregate = new AggregateForUpdateDto
            {
                MaterialNumber = int.Parse(_aggregateInput.MaterialNumber),
                Name = _aggregateInput.Name,
                HotBinId = _aggregateInput.HotBinId
            };

            await _service.AggregateService.UpdateAggregateAsync(SelectedAggregate.Id, updatedAggregate, trackChanges: true);

            await LoadAggregatesAsync();
            editMode = false;
        }
        else
        {
            // Create new aggregate
            await CreateNewAggregateAsync();
        }        
    }

    private async Task CreateNewAggregateAsync()
    {
        var aggregateToCreate = new AggregateForCreationDto
        {
            MaterialNumber = int.Parse(_aggregateInput.MaterialNumber),
            Name = _aggregateInput.Name,
            HotBinId = _aggregateInput.HotBinId
        };
        await _service.AggregateService.CreateAggregateAsync(aggregateToCreate, trackChanges: false);
        await LoadAggregatesAsync();

        CreateNewDto();
    }

    private void CreateNewDto()
    {
        _aggregateInput = new();
        _editContext = new EditContext(_aggregateInput);
        editMode = true;
    }

    private void HandleRowClick(FluentDataGridRow<AggregateDto> agg)
    {
        // If we hit here we have an aggregate selected
        SelectedAggregate = agg.Item;

        if (SelectedAggregate is not null)
        {
            var editModel = new AggregateInputModel
            {
                MaterialNumber = SelectedAggregate.Materialnumber.ToString(),
                Name = SelectedAggregate.Name ?? string.Empty,
                HotBinId = SelectedAggregate.HotBinId
            };

            _aggregateInput = editModel;
        }

        _editContext = new EditContext(_aggregateInput);
        editMode = false;

    }

    private async Task DeleteAggregateAsync()
    {
        await _service.AggregateService.DeleteAggregateAsync(SelectedAggregate.Id, trackChanges: true);

        await LoadAggregatesAsync();

        // Reset the input model and selected aggregate
        CreateNewDto();

        SelectedAggregate = null;
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