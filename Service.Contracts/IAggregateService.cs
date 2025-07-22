using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IAggregateService
{
    Task<IEnumerable<AggregateDto>> GetAggregatesAsync(bool trackChanges);
    Task<AggregateDto> GetAggregateAsync(int aggregateId, bool trackChanges);
    Task<AggregateDto> CreateAggregateAsync(AggregateForCreationDto aggregateForCreation, bool trackChanges);
}
