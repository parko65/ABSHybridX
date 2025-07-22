using Contracts;
using Entities.Models;

namespace Repository;
public class HotBinRepository : RepositoryBase<HotBin>, IHotBinRepository
{
    public HotBinRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }    
}
