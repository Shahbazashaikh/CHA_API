using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace CHA_API.Service.MapperProfile
{
    public static class AutomapperCollection
    {
        public static TDestination MapCollection<TSource, TDestination, TMapperProfile>(this IMapper automapper,
                                                                                        TSource source,
                                                                                        TDestination destination)
        {
            Mapper autoMapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddCollectionMappers();
                config.AddProfile(typeof(TMapperProfile));
            }));
            return autoMapper.Map(source, destination);
        }
    }
}
