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
    public class AuthorController : Controller
    {
        private readonly IAuthorLogic authorLogic;   

        public AuthorController(IAuthorLogic authorLogic)
        {
            this.authorLogic = authorLogic;
        }

        // GET: Author
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<AuthorViewModel>>(authorLogic.GetAll());
            return View(model);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(Author model)
        {
            try
            {
                if (ModelState.IsValid && authorLogic.Add(model))
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
            var model = Mapper.Map<AuthorViewModel>(authorLogic.GetById(id));
            return View(model);
        }

        // POST: Author/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult EditComfirmed(Author model)
        {
            try
            {
                if (ModelState.IsValid && authorLogic.Edit(model))
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
            var model = authorLogic.GetById(id);
            return View(model);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (authorLogic.Delete(id))
                {
                    return RedirectToAction("Index");
                }

                var model = Mapper.Map<AuthorViewModel>(authorLogic.GetById(id));
                return View(model);
            }
            catch
            {
                var model = Mapper.Map<AuthorViewModel>(authorLogic.GetById(id));
                return View(model);
            }
        }
    }
}
