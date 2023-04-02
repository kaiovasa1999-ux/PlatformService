using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatfromProfile : Profile
    {
        public PlatfromProfile()
        {
            //from => to
            //source => target

            CreateMap<Platform, PlatfromReadDTO>();
            CreateMap<PlatfromCreateDTO, Platform>();

        }
    }
}
