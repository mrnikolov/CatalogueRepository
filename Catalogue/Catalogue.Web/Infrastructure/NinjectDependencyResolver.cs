using log4net;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalogue.Models.Entities;
using Catalogue.Models.Services;
using Catalogue.Web.Controllers;

namespace Catalogue.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ILog>().ToMethod(x => LogManager.GetLogger(typeof(Controller)))
                .InSingletonScope();
            kernel.Bind(typeof(ICatalogueContext)).To(typeof(CatalogueContext));
            kernel.Bind(typeof(IProductService)).To(typeof(ProductService));
            kernel.Bind(typeof(ICatalogueContext)).To(typeof(ProductService));
            kernel.Bind(typeof(IManufacturerService)).To(typeof(ManufacturerService));
            kernel.Bind(typeof(ICategoryService)).To(typeof(CategoryService));

        }
    }
}