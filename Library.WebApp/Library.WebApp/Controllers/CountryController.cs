using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryLogic countryLogic;

        public CountryController(ICountryLogic countryLogic)
        {
            this.countryLogic = countryLogic;
        }
        // GET: Country
        public ActionResult Index()
        {
            var model = countryLogic.GetAll();
            return View(model);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (countryLogic.Add(model))
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
            var model = countryLogic.GetById(id);
            return View(model);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (countryLogic.Edit(model))
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
            var model = countryLogic.GetById(id);
            return View(model);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (countryLogic.Delete(id))
                {
                    return RedirectToAction("Index");
                }

                var model = countryLogic.GetById(id);
                return View(model);
            }
            catch
            {
                var model = countryLogic.GetById(id);
                return View(model);
            }
        }
    }
}
