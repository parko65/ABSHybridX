using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class AggregateRepository : RepositoryBase<Aggregate>, IAggregateRepository
{
    public AggregateRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    // Additional methods specific to Aggregate can be added here

    public async Task<IEnumerable<Aggregate>> GetAggregatesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(a => a.Materialnumber)
            .ToListAsync();
    }

    public async Task<Aggregate?> GetAggregateAsync(int aggregateId, bool trackChanges)
    {
        return await FindByCondition(a => a.Id.Equals(aggregateId), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateAggregate(Aggregate aggregate)
    {
        Create(aggregate);
        // No need to save changes here, as it will be handled by the unit of work in the service layer
    }

    public void DeleteAggregate(Aggregate aggregate)
    {
        Delete(aggregate);
        // No need to save changes here, as it will be handled by the unit of work in the service layer
    }
}
