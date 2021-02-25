using AutoMapper;
using Next.Steps.Application.Dto;
using Next.Steps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Application.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonReadDto>()
                .ForMember(p => p.Birthdate, opt =>
                opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            CreateMap<PersonWriteDto, Person>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Birthdate, opt =>
                opt.MapFrom(src => (DateTime)src.Birthdate));

            CreateMap<Hobby, HobbyDto>().ReverseMap();
            CreateMap<HobbyDto, Hobby>();
        }
    }
}