using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class PublishingAutoMapperProfile : Profile
    {
        public PublishingAutoMapperProfile()
        {
            CreateMap<Publishing, PublishingViewModel>();
            CreateMap<CreatePublishingViewModel, Publishing>();
            CreateMap<Publishing, EditPublishingViewModel>();
            CreateMap<EditPublishingViewModel, Publishing>();
        }
    }
}