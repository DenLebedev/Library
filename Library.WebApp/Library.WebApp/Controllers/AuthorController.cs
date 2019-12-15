using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Library.Entities;
using Library.LogicContracts;
using Library.WebApp.Models.ViewModels;

namespace Library.WebApp.Controllers
{
    [Authorize(Roles = "administartor")]
    public class AuthorController : Controller
    {
        private readonly IAuthorLogic authorLogic;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public AuthorController(IAuthorLogic authorLogic)
        {
            this.authorLogic = authorLogic;
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateAuthorViewModel, Author>();
                cfg.CreateMap<Author, IndexAuthorViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, Author>();
                cfg.CreateMap<Author, DeleteAuthorViewModel>()
                    .ForMember("FullName", opt => opt.MapFrom(src => src.Name + " " + src.Surname));
            });
            mapper = config.CreateMapper();
        }

        // GET: Author
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<IndexAuthorViewModel>>(authorLogic.GetAll());
            return View(model);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(CreateAuthorViewModel model)
        {
            var author = mapper.Map<CreateAuthorViewModel, Author>(model);
            try
            {
                if (ModelState.IsValid && authorLogic.Add(author))
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

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<Author, AuthorViewModel>(authorLogic.GetById(id));
            return View(model);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(AuthorViewModel model)
        {
            var author = mapper.Map<AuthorViewModel, Author>(model);
            try
            {
                if (ModelState.IsValid && authorLogic.Edit(author))
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<Author, DeleteAuthorViewModel>(authorLogic.GetById(id));
            return View(model);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<DeleteAuthorViewModel>(authorLogic.GetById(id));
            try
            {
                if (authorLogic.Delete(id))
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
