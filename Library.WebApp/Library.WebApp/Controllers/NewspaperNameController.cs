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
    [Authorize(Roles = "administartor")]
    public class NewspaperNameController : Controller
    {
        private readonly INewspaperNameLogic nameLogic;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public NewspaperNameController(INewspaperNameLogic nameLogic)
        {
            this.nameLogic = nameLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewspaperName, NewspaperNameViewModel>();
                cfg.CreateMap<CreateNewspaperNameViewModel, NewspaperName>();
                cfg.CreateMap<NewspaperName, EditNewspaperNameViewModel>();
                cfg.CreateMap<EditNewspaperNameViewModel, NewspaperName>();
            });
            this.mapper = config.CreateMapper();
        }

        // GET: NewspaperName
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<NewspaperNameViewModel>>(nameLogic.GetAll());
            return View(model);
        }

        // GET: NewspaperName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewspaperName/Create
        [HttpPost]
        public ActionResult Create(CreateNewspaperNameViewModel model)
        {
            var newspaperName = mapper.Map<CreateNewspaperNameViewModel, NewspaperName>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (nameLogic.Add(newspaperName))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: NewspaperName/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<NewspaperName, EditNewspaperNameViewModel>(nameLogic.GetById(id));
            return View(model);
        }

        // POST: NewspaperName/Edit/5
        [HttpPost]
        public ActionResult Edit(EditNewspaperNameViewModel model)
        {
            var newspaperName = mapper.Map<EditNewspaperNameViewModel, NewspaperName>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (nameLogic.Edit(newspaperName))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: NewspaperName/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<NewspaperName, NewspaperNameViewModel>(nameLogic.GetById(id));
            return View(model);
        }

        // POST: NewspaperName/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<NewspaperName, NewspaperNameViewModel>(nameLogic.GetById(id));
            try
            {
                if (nameLogic.Delete(id))
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
