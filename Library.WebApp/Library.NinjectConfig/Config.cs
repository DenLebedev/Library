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
                .Bind<IAuthorDao>()
                .To<SqlDal.AuthorDao>()
                .InSingletonScope();

            kernel
                .Bind<ICityDao>()
                .To<SqlDal.CityDao>()
                .InSingletonScope();
        }
    }
}
