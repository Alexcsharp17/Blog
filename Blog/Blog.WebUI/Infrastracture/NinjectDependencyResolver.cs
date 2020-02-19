using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Infrastracture
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

       
            // Здесь размещаются привязки
            private void AddBindings()
            {
            kernel.Bind<IArticleRepository>().To<EFBlogRepository>();
            kernel.Bind<IReviewRepository>().To<EFBlogRepository>();
            kernel.Bind<IAuthorRepository>().To<EFBlogRepository>();
            kernel.Bind<ITagRepository>().To<EFBlogRepository>();
        }
    }
}