using Contracts;
using Entities.Models;

namespace Repository;
public class AggregateRepository : RepositoryBase<Aggregate>, IAggregateRepository
{
    public AggregateRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    // Additional methods specific to Aggregate can be added here
}
