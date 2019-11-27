using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class NewspaperNameController : Controller
    {
        private readonly INewspaperNameLogic nameLogic;

        public NewspaperNameController(INewspaperNameLogic nameLogic)
        {
            this.nameLogic = nameLogic;
        }

        // GET: NewspaperName
        public ActionResult Index()
        {
            var model = nameLogic.GetAll();
            return View(model);
        }

        // GET: NewspaperName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewspaperName/Create
        [HttpPost]
        public ActionResult Create(NewspaperName model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nameLogic.Add(model))
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
            var model = nameLogic.GetById(id);
            return View(model);
        }

        // POST: NewspaperName/Edit/5
        [HttpPost]
        public ActionResult Edit(NewspaperName model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (nameLogic.Edit(model))
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
            var model = nameLogic.GetById(id);
            return View(model);
        }

        // POST: NewspaperName/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (nameLogic.Delete(id))
                {
                    return RedirectToAction("Index");
                }

                var model = nameLogic.GetById(id);
                return View(model);
            }
            catch
            {
                var model = nameLogic.GetById(id);
                return View(model);
            }
        }
    }
}
