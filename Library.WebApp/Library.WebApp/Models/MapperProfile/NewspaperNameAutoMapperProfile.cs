using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class NewspaperNameAutoMapperProfile : Profile
    {
        public NewspaperNameAutoMapperProfile()
        {
            CreateMap<NewspaperName, NewspaperNameViewModel>();
            CreateMap<CreateNewspaperNameViewModel, NewspaperName>();
            CreateMap<NewspaperName, EditNewspaperNameViewModel>();
            CreateMap<EditNewspaperNameViewModel, NewspaperName>();
        }
    }
}