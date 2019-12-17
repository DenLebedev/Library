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
using System.Web.Security;

namespace Library.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic user;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public HomeController(IUserLogic userLogic)
        {
            this.user = userLogic;
            config = new MapperConfiguration(cfg => {
                cfg.AddProfile<HomeAutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Username == null)
            {
                ModelState.AddModelError("Username", "This is a required field");
            }
            if (model.Username.Length > 50)
            {
                ModelState.AddModelError("Username", "Username length can't be more than 50 characters");
            }

            if (model.Password == null)
            {
                ModelState.AddModelError("Password", "This is a required field");
            }
            if (model.Password.Length > 50)
            {
                ModelState.AddModelError("Password", "Password length can't be more than 50 characters");
            }

            try
            {
                var userLogin = mapper.Map<LoginViewModel, User>(model);
                if (ModelState.IsValid)
                {
                    if (user.Login(userLogin))
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, createPersistentCookie: true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Username or Password");
                        return View(model);
                    }
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel model)
        {            
            try
            {
                var newUser = mapper.Map<RegistrationViewModel, User>(model);
                if (ModelState.IsValid)
                {
                    if (user.Add(newUser))
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "A user with this Username already exists");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }                
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [ChildActionOnly]
        public ActionResult LoginBlock()
        {
            if (User.Identity.IsAuthenticated)
            {
                return PartialView("_LogoutPartial");
            }
            else
            {
                return PartialView("_LoginPartial");
            }
        }

        [ChildActionOnly]
        public ActionResult MainAdminMenuBlock()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("administartor"))
                {
                    return PartialView("_MainAdminMenuPartial");
                }
                else
                {
                    return PartialView("_MainUserMenuPartial");
                }
            }
            else
            {
                return PartialView("_MainMenuPartial");
            }
        }
    }
}
