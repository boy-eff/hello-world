using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using HelloWorld.Domain.Entities;
using AutoMapper;

namespace HelloWorld.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>()
                .ForMember(u => u.UserName, u => u.MapFrom(r => r.UserName.ToLower()));
            CreateMap<CreateCollectionDto, WordCollection>()
                .ForMember(wc => wc.WordCollectionThemeId, wc => wc.MapFrom(cc => cc.ThemeId));
            CreateMap<Word, WordDto>();
            CreateMap<WordCollection, CollectionDto>()
                .ForMember(cd => cd.Words, w => w.MapFrom(wc => wc.Words));
            CreateMap<WordCollectionTheme, WordCollectionThemeDto>();
            CreateMap<AppUser, UserInfoDto>()
                .ForMember(member => member.PhotoUrl, m => m.MapFrom(u => u.Photo.Url));
        }
    }
}