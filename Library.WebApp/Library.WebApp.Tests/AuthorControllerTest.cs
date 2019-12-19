using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Library.LogicContracts;
using Library.WebApp.Controllers;
using Library.WebApp.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Library.Entities;
using AutoMapper;
using Library.WebApp.Models.MapperProfile;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Reflection;

namespace Library.WebApp.Tests
{
    [TestClass]
    public class AuthorControllerTest
    {
        #region NotNullTests

        [TestMethod]
        public void IndexView_NotNull()
        {
            var mock = new Mock<IAuthorLogic>();
            mock.Setup(a => a.GetAll()).Returns(new List<Author>());
            AuthorController controller = new AuthorController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateView_NotNull()
        {
            var mock = new Mock<IAuthorLogic>();
            mock.Setup(a => a.Add(new Author()));
            AuthorController controller = new AuthorController(mock.Object);
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditView_NotNull()
        {
            var mock = new Mock<IAuthorLogic>();
            mock.Setup(a => a.Edit(new Author()));
            AuthorController controller = new AuthorController(mock.Object);
            ViewResult result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteView_NotNull()
        {
            var mock = new Mock<IAuthorLogic>();
            mock.Setup(a => a.Delete(1));
            AuthorController controller = new AuthorController(mock.Object);
            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteConfirmedView_NotNull()
        {
            var mock = new Mock<IAuthorLogic>();
            mock.Setup(a => a.Delete(1));
            AuthorController controller = new AuthorController(mock.Object);
            ViewResult result = controller.DeleteConfirmed(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        #endregion

        #region ModelErrorTests

        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            var mock = new Mock<IAuthorLogic>();
            CreateAuthorViewModel author = new CreateAuthorViewModel();
            AuthorController controller = new AuthorController(mock.Object);
            controller.ModelState.AddModelError("Name", "Model have no name");
            ViewResult result = controller.Create(author) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPostAction_ModelError()
        {
            var mock = new Mock<IAuthorLogic>();
            AuthorViewModel author = new AuthorViewModel();
            var controller = new AuthorController(mock.Object);
            controller.ModelState.AddModelError("Name", "Model have no name");
            ViewResult result = controller.Edit(author) as ViewResult;
            Assert.IsNotNull(result);
        }

        #endregion       

        [TestMethod]
        public void CreatePostAction_ReturnsRedirectToRouteResult()
        {
            var mock = new Mock<IAuthorLogic>();
            CreateAuthorViewModel authorVM = new CreateAuthorViewModel()
            { Name = "Alex", Surname = "Noi"};
            var author = new Author() 
            { Name = "Alex", Surname = "Noi" };
            mock.Setup(a => a.Add(author)).Returns(true);
            var controller = new AuthorController(mock.Object);            
            var result = controller.Create(authorVM) as RedirectToRouteResult;
            Assert.AreEqual("Index", result);
        }
    }
}
