using Contracts;
using Service.Contracts;
using AutoMapper;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IRecipeService> _recipeService;    

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, logger, mapper));        
    }

    public IRecipeService RecipeService => _recipeService.Value;    
}
