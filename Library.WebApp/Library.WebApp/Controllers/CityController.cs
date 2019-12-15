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
    public class CityController : Controller
    {
        private readonly ICityLogic cityLogic;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public CityController(ICityLogic cityLogic)
        {
            this.cityLogic = cityLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.CreateMap<City, CityViewModel>();
                cfg.CreateMap<CreateCityViewModel, City>();
                cfg.CreateMap<City, EditCityViewModel>();
                cfg.CreateMap<EditCityViewModel, City>();
            });
            this.mapper = config.CreateMapper();
        }
        // GET: City
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<CityViewModel>>(cityLogic.GetAll());
            return View(model);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(CreateCityViewModel model)
        {
            var city = mapper.Map<CreateCityViewModel, City>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (cityLogic.Add(city))
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<City, EditCityViewModel>(cityLogic.GetById(id));
            return View(model);
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCityViewModel model)
        {
            var city = mapper.Map<EditCityViewModel,City>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (cityLogic.Edit(city))
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

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<City, CityViewModel>(cityLogic.GetById(id));
            return View(model);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<City, CityViewModel>(cityLogic.GetById(id));
            try
            {
                if (cityLogic.Delete(id))
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
