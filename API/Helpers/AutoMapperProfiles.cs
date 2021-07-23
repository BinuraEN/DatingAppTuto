using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extenstions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                         src.Photos.FirstOrDefault(photo =>
                             photo.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                         src.DateOfBirth.CalculateAge()));

            //since if calculate age is done at entity, it will retrirve all user details in order to do the calculation
            CreateMap<Photo, PhotoDTO>();
        }
    }
}