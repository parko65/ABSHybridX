namespace Service.Contracts;

public interface IServiceManager
{
    IRecipeService RecipeService { get; }
    IHotBinService HotBinService { get; }
    IAggregateService AggregateService { get; }
}
