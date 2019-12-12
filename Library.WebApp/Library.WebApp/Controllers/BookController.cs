using AutoMapper;
using Library.Entities;
using Library.LogicContracts;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookLogic books;
        private readonly IAuthorLogic authors;
        private readonly ICityLogic cities;
        private readonly IPublishingLogic publishings;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public BookController(IBookLogic bookLogic, IAuthorLogic authorLogic, ICityLogic cityLogic, IPublishingLogic publishingLogic)
        {
            this.books = bookLogic;
            this.authors = authorLogic;
            this.cities = cityLogic;
            this.publishings = publishingLogic;

            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Book, IndexBookViewModel>()
                    .ForMember("IndexName", opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname + " - " + src.Name + " " + src.YearPublication));
                cfg.CreateMap<Book, DetailsBookViewModel>();
                cfg.CreateMap<Book, CreateBookViewModel>();
                cfg.CreateMap<CreateBookViewModel, Book>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.MarkDelete, opt => opt.Ignore())
                    .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId))
                    .ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
                    .ForPath(dest => dest.Publishing.Id, opt => opt.MapFrom(src => src.PublishingId));
                cfg.CreateMap<Book, EditBookViewModel>()
                    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Id));
                cfg.CreateMap<EditBookViewModel, Book>()
                    .ForMember(dest => dest.MarkDelete, opt => opt.Ignore())
                    .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => src.AuthorId))
                    .ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
                    .ForPath(dest => dest.Publishing.Id, opt => opt.MapFrom(src => src.PublishingId));
                cfg.CreateMap<Book, DeleteBookViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname + " - " + src.Name + " " + src.YearPublication));
            });
            mapper = config.CreateMapper();
        }

        // GET: Book
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<IndexBookViewModel>>(books.GetAll());
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var model = mapper.Map<DetailsBookViewModel>(books.GetById(id));          
            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = new CreateBookViewModel(authors, cities, publishings);
            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(CreateBookViewModel model)
        {
            var book = mapper.Map<CreateBookViewModel, Book>(model);
            try
            {
                if (books.Add(book))
                {
                    return RedirectToAction("Index");
                }

                model = new CreateBookViewModel(authors, cities, publishings);
                return View(model);
            }
            catch
            {
                model = new CreateBookViewModel(authors, cities, publishings);
                return View(model);
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<EditBookViewModel>(books.GetById(id));
            model.SetAuthors(authors.GetAll().ToList());
            model.SetCities(cities.GetAll().ToList());
            model.SetPublishings(publishings.GetAll().ToList());
            return View(model);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(EditBookViewModel model)
        {
            var book = mapper.Map<EditBookViewModel, Book>(model);
            model.SetAuthors(authors.GetAll().ToList());
            model.SetCities(cities.GetAll().ToList());
            model.SetPublishings(publishings.GetAll().ToList());
            try
            {
                if (ModelState.IsValid && books.Edit(book))
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<DeleteBookViewModel>(books.GetById(id));
            return View(model);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<DeleteBookViewModel>(books.GetById(id));
            try
            {
                if (books.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
    }
}
