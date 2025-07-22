using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IHotBinService
{
    Task<IEnumerable<HotBinDto>> GetHotBinsAsync(bool trackChanges);
}
