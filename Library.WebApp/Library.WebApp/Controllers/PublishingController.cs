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
    public class PublishingController : Controller
    {
        private readonly IPublishingLogic publishingLogic;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public PublishingController(IPublishingLogic publishingLogic)
        {
            this.publishingLogic = publishingLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Publishing, PublishingViewModel>();
                cfg.CreateMap<CreatePublishingViewModel, Publishing>();
                cfg.CreateMap<Publishing, EditPublishingViewModel>();
                cfg.CreateMap<EditPublishingViewModel, Publishing>();
            });
            this.mapper = config.CreateMapper();
        }

        // GET: Publishing
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<PublishingViewModel>>(publishingLogic.GetAll());
            return View(model);
        }

        // GET: Publishing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishing/Create
        [HttpPost]
        public ActionResult Create(CreatePublishingViewModel model)
        {
            var publishing = mapper.Map<CreatePublishingViewModel, Publishing>(model);
            try
            {
                if (ModelState.IsValid)
                { 
                    if(publishingLogic.Add(publishing))
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
            var model = mapper.Map<Publishing, EditPublishingViewModel>(publishingLogic.GetById(id));
            return View(model);
        }

        // POST: Publishing/Edit/5
        [HttpPost]
        public ActionResult Edit(EditPublishingViewModel model)
        {
            var publishing = mapper.Map<EditPublishingViewModel, Publishing>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    if (publishingLogic.Edit(publishing))
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
            var model = mapper.Map<Publishing, PublishingViewModel>(publishingLogic.GetById(id));
            return View(model);
        }

        // POST: Publishing/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<Publishing, PublishingViewModel>(publishingLogic.GetById(id));
            try
            {
                if (publishingLogic.Delete(id))
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
