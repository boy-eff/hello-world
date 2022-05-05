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
            CreateMap<CreateCollectionDto, WordCollection>();
            CreateMap<Word, WordDto>();
            CreateMap<WordCollection, CollectionDto>()
                .ForMember(cd => cd.Words, w => w.MapFrom(wc => wc.Words));
            CreateMap<WordCollectionTheme, WordCollectionThemeDto>();
        }
    }
}