using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class CountryAutoMapperProfile : Profile
    {
        public CountryAutoMapperProfile()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CreateCountryViewModels, Country>();
            CreateMap<Country, EditCountryViewModel>();
            CreateMap<EditCountryViewModel, Country>();
        }
    }
}