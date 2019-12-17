using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class HomeAutoMapperProfile : Profile
    {
        public HomeAutoMapperProfile()
        {
            CreateMap<LoginViewModel, User>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Username));
            CreateMap<RegistrationViewModel, User>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Username));
        }
    }
}