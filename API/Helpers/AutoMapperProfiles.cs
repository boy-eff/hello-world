using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.Helpers
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
        }
    }
}