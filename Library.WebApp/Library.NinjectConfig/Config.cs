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
                .Bind<ICatalogueCartLogic>()
                .To<CatalogueLogic.CatalogueCartLogic>()
                .InSingletonScope();

            kernel
                .Bind<IAuthorLogic>()
                .To<CatalogueLogic.AuthorLogic>()
                .InSingletonScope();

            kernel
                .Bind<ICatalogueCartDao>()
                .To<SqlDal.CatalogueCartDao>()
                .InSingletonScope();

            kernel
                .Bind<IAuthorDao>()
                .To<SqlDal.AuthorDao>()
                .InSingletonScope();
        }
    }
}
