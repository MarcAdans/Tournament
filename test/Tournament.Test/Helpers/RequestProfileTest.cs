using AutoMapper;
using Tournament.Domain.Lambda3Context.Models;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Test
{
    public class RequestProfileTest : Profile
    {
        public RequestProfileTest()
        {
            CreateMap<Lambda3Movie, Movie>();
        }
    }
}