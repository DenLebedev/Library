using System;
using AutoMapper;
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

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>();
            });
            Mapper.AssertConfigurationIsValid();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, DetailsBookViewModel>();
            });
            Mapper.AssertConfigurationIsValid();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}