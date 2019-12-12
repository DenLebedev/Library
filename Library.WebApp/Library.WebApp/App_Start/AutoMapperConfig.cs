using System;
using AutoMapper;
using AutoMapper.Configuration;
using Library.Entities;
using Library.WebApp.Models.ViewModels;

namespace Library.WebApp
{
    public  class AutoMapperConfig
    {
        public static void RegisterMaps()
        {

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<BookViewModel, Book>().ForMember(dest => dest.MarkDelete, opt => opt.UseValue(false));
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<BookViewModel, Book>();
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, BookViewModel>();
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, DetailsBookViewModel>();
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Author, AuthorViewModel>();
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Book, BookViewModel>();
            //});
            //Mapper.AssertConfigurationIsValid();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<CreateBookViewModel, Book>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.MarkDelete, opt => opt.Ignore());
            //    //.ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId))
            //    //.ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
            //    //.ForPath(dest => dest.Publishing.Id, opt => opt.MapFrom(src => src.PublishingId));
            //});

            //Mapper.AssertConfigurationIsValid();
        }
    }
}