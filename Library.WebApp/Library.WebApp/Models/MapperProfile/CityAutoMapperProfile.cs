using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class CityAutoMapperProfile : Profile
    {
        public CityAutoMapperProfile()
        {
            CreateMap<City, CityViewModel>();
            CreateMap<CreateCityViewModel, City>();
            CreateMap<City, EditCityViewModel>();
            CreateMap<EditCityViewModel, City>();
        }
    }
}