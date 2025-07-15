using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
{
    public RecipeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)            
            .OrderBy(r => r.Id)
            .ToListAsync();
    }    

    public async Task<Recipe?> GetRecipeAsync(int recipeId, bool trackChanges)
    {
        return await FindByCondition(r => r.Id == recipeId, trackChanges)            
            .SingleOrDefaultAsync();
    }    
}
