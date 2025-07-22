namespace Contracts;

public interface IRepositoryManager
{
    IRecipeRepository Recipe { get; }
    IHotBinRepository HotBin { get; }
    IAggregateRepository Aggregate { get; }
    Task SaveAsync();
}
