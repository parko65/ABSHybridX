using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class RecipeService : IRecipeService
{
    private readonly IRepositoryManager _repository;    
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RecipeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RecipeDto>> GetRecipesAsync(bool trackChanges)
    {
        var recipes = await _repository.Recipe.GetRecipesAsync(trackChanges);

        var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);

        return recipeDtos;
    }

    public async Task<RecipeDto> GetRecipeAsync(int id, bool trackChanges)
    {
        var recipe = await _repository.Recipe.GetRecipeAsync(id, trackChanges);
        if (recipe is null)
            throw new RecipeNotFoundException(id);

        var recipeDto = _mapper.Map<RecipeDto>(recipe);

        return recipeDto;
    }

    
}