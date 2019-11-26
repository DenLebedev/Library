using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityLogic cityLogic;

        public CityController(ICityLogic cityLogic)
        {
            this.cityLogic = cityLogic;
        }
        // GET: City
        public ActionResult Index()
        {
            var model = cityLogic.GetAll();
            return View(model);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City model)
        {
            try
            {
                if (ModelState.IsValid && cityLogic.Add(model))
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var model = cityLogic.GetById(id);
            return View(model);
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(City model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cityLogic.Edit(model))
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
            var model = cityLogic.GetById(id);
            return View(model);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (cityLogic.Delete(id))
                {
                    return RedirectToAction("Index");
                }

                var model = cityLogic.GetById(id);
                return View(model);
            }
            catch
            {
                var model = cityLogic.GetById(id);
                return View(model);
            }
        }
    }
}
