using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class UserAdministartionAutoMapperProfile : Profile
    {
        public UserAdministartionAutoMapperProfile()
        {
            CreateMap<User, IndexUserViewModel>()
                .ForMember("Username", opt => opt.MapFrom(src => src.Name))
                .ForMember("UserRoleName", opt => opt.MapFrom(src => src.RoleName));
            CreateMap<User, EditUserViewModel>();
            CreateMap<EditUserViewModel, User>()
                .ForMember("RoleId", opt => opt.MapFrom(src => src.RoleId));
            CreateMap<User, DeleteUserViewModel>();
        }
    }
}