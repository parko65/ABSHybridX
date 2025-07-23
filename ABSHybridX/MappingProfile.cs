using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace ABSHybridX;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add your mapping configurations here
        // For example:
        // CreateMap<SourceModel, DestinationModel>();

        CreateMap<Recipe, RecipeDto>();

        CreateMap<HotBin, HotBinDto>();

        CreateMap<Aggregate, AggregateDto>();
        CreateMap<AggregateForCreationDto, Aggregate>();
    }
}