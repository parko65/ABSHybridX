using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IRecipeRepository> _recipeRepository;
    private readonly Lazy<IHotBinRepository> _hotBinRepository;
    private readonly Lazy<IAggregateRepository> _aggregateRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _recipeRepository = new Lazy<IRecipeRepository>(() => new RecipeRepository(_repositoryContext));
        _hotBinRepository = new Lazy<IHotBinRepository>(() => new HotBinRepository(_repositoryContext));
        _aggregateRepository = new Lazy<IAggregateRepository>(() => new AggregateRepository(_repositoryContext));
    }
    public IRecipeRepository Recipe => _recipeRepository.Value;
    public IHotBinRepository HotBin => _hotBinRepository.Value;
    public IAggregateRepository Aggregate => _aggregateRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
