using Contracts;
using Service.Contracts;
using AutoMapper;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IRecipeService> _recipeService;
    private readonly Lazy<IHotBinService> _hotBinService;
    private readonly Lazy<IAggregateService> _aggregateService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, logger, mapper));
        _hotBinService = new Lazy<IHotBinService>(() => new HotBinService(repositoryManager, logger, mapper));
        _aggregateService = new Lazy<IAggregateService>(() => new AggregateService(repositoryManager, logger, mapper));
    }

    public IRecipeService RecipeService => _recipeService.Value;
    public IHotBinService HotBinService => _hotBinService.Value;
    public IAggregateService AggregateService => _aggregateService.Value;
}
