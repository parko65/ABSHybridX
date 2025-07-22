using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class HotBinRepository : RepositoryBase<HotBin>, IHotBinRepository
{
    public HotBinRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<HotBin>> GetHotBinsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(hb => hb.Name)
            .ToListAsync();
    }
}
