using Entities.Models;

namespace Contracts;
public interface IHotBinRepository
{
    Task<IEnumerable<HotBin>> GetHotBinsAsync(bool trackChanges);
}
