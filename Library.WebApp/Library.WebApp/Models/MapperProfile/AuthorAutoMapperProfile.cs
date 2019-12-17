using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class AuthorAutoMapperProfile : Profile
    {
        public AuthorAutoMapperProfile()
        {
            CreateMap<CreateAuthorViewModel, Author>();
            CreateMap<Author, IndexAuthorViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<Author, DeleteAuthorViewModel>()
                .ForMember("FullName", opt => opt.MapFrom(src => src.Name + " " + src.Surname));
        }
    }
}