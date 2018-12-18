using AutoMapper;

namespace Tournament.Test
{
    public static class MapperHelper
    {
        public static IMapper GetMapper()
        {
            var configuration =
                new MapperConfiguration(cfg => cfg.AddProfile(new RequestProfileTest()));
            return new Mapper(configuration);
        }
    }
}