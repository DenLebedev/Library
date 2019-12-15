using System;
using System.Configuration;
using Ninject;
using Ninject.Web.Common;
using Library.LogicContracts;
using Library.DalContracts;

namespace Library.NinjectConfig
{
    public static class Config
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            #region BL

            kernel
                .Bind<SqlDal.SqlDalConfig>()
                .To<SqlDal.SqlDalConfig>()
                .InSingletonScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["LibraryCatalogueDB"].ConnectionString);

            kernel
                .Bind<IAuthorLogic>()
                .To<CatalogueLogic.AuthorLogic>()
                .InSingletonScope();

            kernel
                .Bind<ICityLogic>()
                .To<CatalogueLogic.CityLogic>()
                .InSingletonScope();

            kernel
                .Bind<IPublishingLogic>()
                .To<CatalogueLogic.PublishingLogic>()
                .InSingletonScope();

            kernel
                .Bind<ICountryLogic>()
                .To<CatalogueLogic.CountryLogic>()
                .InSingletonScope();

            kernel
                .Bind<INewspaperNameLogic>()
                .To<CatalogueLogic.NewspaperNameLogic>()
                .InSingletonScope();

            kernel
                .Bind<IBookLogic>()
                .To<CatalogueLogic.BookLogic>()
                .InSingletonScope();

            kernel
                .Bind<IUserLogic>()
                .To<CatalogueLogic.UserLogic>()
                .InSingletonScope();

            kernel
                .Bind<IUserRoleLogic>()
                .To<CatalogueLogic.UserRoleLogic>()
                .InSingletonScope();

            #endregion

            #region BLValidation

            kernel
                .Bind<IAuthorValidationLogic>()
                .To<CatalogueLogic.AuthorValidationLogic>()
                .InSingletonScope();

            kernel
                .Bind<IBookValidationLogic>()
                .To<CatalogueLogic.BookValidationLogic>()
                .InSingletonScope();

            kernel
                .Bind<IUserValidationLogic>()
                .To<CatalogueLogic.UserValidationLogic>()
                .InSingletonScope();

            #endregion

            #region DAL

            kernel
                .Bind<IAuthorDao>()
                .To<SqlDal.AuthorDao>()
                .InSingletonScope();

            kernel
                .Bind<ICityDao>()
                .To<SqlDal.CityDao>()
                .InSingletonScope();

            kernel
                .Bind<IPublishingDao>()
                .To<SqlDal.PublishingDao>()
                .InSingletonScope();

            kernel
                .Bind<ICountryDao>()
                .To<SqlDal.CountryDao>()
                .InSingletonScope();

            kernel
                .Bind<INewspaperNameDao>()
                .To<SqlDal.NewspaperNameDao>()
                .InSingletonScope();

            kernel
                .Bind<IBookDao>()
                .To<SqlDal.BookDao>()
                .InSingletonScope();

            kernel
                .Bind<IUserDao>()
                .To<SqlDal.UserDao>()
                .InSingletonScope();

            kernel
                .Bind<IUserRoleDao>()
                .To<SqlDal.UserRoleDao>()
                .InSingletonScope();

            #endregion
        }
    }
}
