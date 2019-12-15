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
    public class CountryController : Controller
    {
        private readonly ICountryLogic countryLogic;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public CountryController(ICountryLogic countryLogic)
        {
            this.countryLogic = countryLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Country, CountryViewModel>();
                cfg.CreateMap<CreateCountryViewModels, Country>();
                cfg.CreateMap<Country, EditCountryViewModel>();
                cfg.CreateMap<EditCountryViewModel, Country>();
            });
            this.mapper = config.CreateMapper();
        }
        // GET: Country
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<CountryViewModel>>(countryLogic.GetAll());
            return View(model);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(CreateCountryViewModels model)
        {
            var country = mapper.Map<CreateCountryViewModels, Country>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (countryLogic.Add(country))
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

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<Country, EditCountryViewModel>(countryLogic.GetById(id));
            return View(model);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCountryViewModel model)
        {
            var country = mapper.Map<EditCountryViewModel, Country>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (countryLogic.Edit(country))
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

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<Country, CountryViewModel>(countryLogic.GetById(id));
            return View(model);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<Country, CountryViewModel>(countryLogic.GetById(id));
            try
            {
                if (countryLogic.Delete(id))
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
