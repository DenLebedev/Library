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

        public BookController(IBookLogic bookLogic, IAuthorLogic authorLogic, ICityLogic cityLogic, IPublishingLogic publishingLogic)
        {
            this.books = bookLogic;
            this.authors = authorLogic;
            this.cities = cityLogic;
            this.publishings = publishingLogic;
        }

        // GET: Book
        public ActionResult Index()
        {
            var model = books.GetAll();
            //var model = Mapper.Map<IEnumerable<BookViewModel>>(bookLogic.GetAll());
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            //var model = Mapper.Map<BookViewModel>(bookLogic.GetById(id));
            var model = books.GetById(id);            
            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = new CreateBookViewModel();
            model.Authors = model.SetAuthors(authors.GetAll().ToList());
            model.Cities = model.SetCities(cities.GetAll().ToList());
            model.Publishings = model.SetPublishings(publishings.GetAll().ToList());
            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book model)
        {
            try
            {
                books.Add(model);
                if (books.Add(model))
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

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
