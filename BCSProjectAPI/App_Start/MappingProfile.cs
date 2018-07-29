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
            CreateMap<Employee, EmployeeDto>()
                .ForAllMembers(
                        opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, Employee>()
                .ForMember(
                    dest => dest.Hobbies,
                    opt => opt.Ignore());

            CreateMap<Hobby, HobbyDto>();
            CreateMap<HobbyDto, Hobby>();

            CreateMap<EmployeeCharacteristic, EmployeeCharacteristicDto>()
                     .ForAllMembers(
                        opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<EmployeeCharacteristicDto, EmployeeCharacteristic>()
                     .ForAllMembers(
                        opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                    .ForMember(
                        dest => dest.Role,
                        opt => opt.MapFrom(src => src.Role))
                    .ForPath(
                        dest => dest.Role.RoleName,
                        opt => opt.MapFrom(src => src.Role.RoleName))
                     .ForAllMembers(
                        opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}