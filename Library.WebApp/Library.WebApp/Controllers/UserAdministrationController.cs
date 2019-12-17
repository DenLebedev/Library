using AutoMapper;
using Library.Entities;
using Library.LogicContracts;
using Library.WebApp.Models.MapperProfile;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    public class UserAdministrationController : Controller
    {
        private readonly IUserLogic userLogic;
        private readonly IUserRoleLogic userRoleLogic;
        private readonly IMapper mapper;
        private readonly MapperConfiguration config;

        public UserAdministrationController(IUserLogic userLogic, IUserRoleLogic userRoleLogic)
        {
            this.userLogic = userLogic;
            this.userRoleLogic = userRoleLogic;
            config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserAdministartionAutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        // GET: User
        public ActionResult Index()
        {
            var model = mapper.Map<IEnumerable<IndexUserViewModel>>(userLogic.GetAll());
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = mapper.Map<EditUserViewModel>(userLogic.GetById(id));
            model.SetRoles(userRoleLogic.GetAll().ToList());
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            var user = mapper.Map<EditUserViewModel, User>(model);
            model.SetRoles(userRoleLogic.GetAll().ToList());

            if (model.Name == null)
            {
                ModelState.AddModelError("Name", "This is a required field");
            }

            if (model.Name.Length > 50)
            {
                ModelState.AddModelError("Name", "Name length can't be more than 50 characters");
            }

            try
            {
                if (ModelState.IsValid && userLogic.Edit(user))
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = mapper.Map<DeleteUserViewModel>(userLogic.GetById(id));
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = mapper.Map<DeleteUserViewModel>(userLogic.GetById(id));
            try
            {
                if (userLogic.Delete(id))
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
