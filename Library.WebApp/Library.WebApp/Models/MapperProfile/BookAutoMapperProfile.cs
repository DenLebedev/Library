using AutoMapper;
using Library.Entities;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebApp.Models.MapperProfile
{
    public class BookAutoMapperProfile : Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<Book, IndexBookViewModel>()
                .ForMember("IndexName", opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname + " - " + src.Name + " " + src.YearPublication));
            CreateMap<Book, DetailsBookViewModel>();
            CreateMap<Book, CreateBookViewModel>();
            CreateMap<CreateBookViewModel, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MarkDelete, opt => opt.Ignore())
                .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
                .ForPath(dest => dest.Publishing.Id, opt => opt.MapFrom(src => src.PublishingId));
            CreateMap<Book, EditBookViewModel>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id));
            CreateMap<EditBookViewModel, Book>()
                .ForMember(dest => dest.MarkDelete, opt => opt.Ignore())
                .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId))
                .ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
                .ForPath(dest => dest.Publishing.Id, opt => opt.MapFrom(src => src.PublishingId));
            CreateMap<Book, DeleteBookViewModel>()
                .ForMember("Name", opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname + " - " + src.Name + " " + src.YearPublication));
        }
    }
}