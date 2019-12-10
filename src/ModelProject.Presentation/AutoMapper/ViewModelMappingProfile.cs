using AutoMapper;
using ModelProject.Core.Entities;
using ModelProject.Presentation.ViewModels;

namespace ModelProject.Presentation.AutoMapper
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<TweetViewModel, Tweet>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
