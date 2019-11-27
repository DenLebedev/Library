using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class PublishingController : Controller
    {
        private readonly IPublishingLogic publishingLogic;

        public PublishingController(IPublishingLogic publishingLogic)
        {
            this.publishingLogic = publishingLogic;
        }

        // GET: Publishing
        public ActionResult Index()
        {
            var model = publishingLogic.GetAll();
            return View(model);
        }

        // GET: Publishing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishing/Create
        [HttpPost]
        public ActionResult Create(Publishing model)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    if(publishingLogic.Add(model))
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

        // GET: Publishing/Edit/5
        public ActionResult Edit(int id)
        {
            var model = publishingLogic.GetById(id);
            return View(model);
        }

        // POST: Publishing/Edit/5
        [HttpPost]
        public ActionResult Edit(Publishing model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (publishingLogic.Edit(model))
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

        // GET: Publishing/Delete/5
        public ActionResult Delete(int id)
        {
            var model = publishingLogic.GetById(id);
            return View(model);
        }

        // POST: Publishing/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (publishingLogic.Delete(id))
                {
                    return RedirectToAction("Index");
                }

                var model = publishingLogic.GetById(id);
                return View(model);
            }
            catch
            {
                var model = publishingLogic.GetById(id);
                return View(model);
            }
        }
    }
}
