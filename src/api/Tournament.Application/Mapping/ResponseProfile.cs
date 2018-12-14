using AutoMapper;
using Tournament.Domain.Lambda3Context.Models;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Application.Mapping
{
    internal class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Lambda3Movie, Movie>();
        }
    }
}