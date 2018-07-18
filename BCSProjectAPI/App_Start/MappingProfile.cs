using AutoMapper;
using BCSProjectAPI.DataLayer.Dtos;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCSProjectAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, Employee>()
                .ForMember(
                    dest => dest.Hobbies,
                    opt => opt.NullSubstitute(null))
                .ForMember(
                    dest => dest.Interests,
                    opt => opt.NullSubstitute(null));

            CreateMap<Hobby, HobbyDto>();
            CreateMap<HobbyDto, Hobby>();

            CreateMap<Interest, InterestDto>();
            CreateMap<InterestDto, Interest>();
        }
    }
}