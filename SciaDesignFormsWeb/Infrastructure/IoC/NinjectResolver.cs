using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject;

namespace SciaDesignFormsWeb.Infrastructure.IoC
{
    public class NinjectResolver : System.Web.Http.Dependencies.IDependencyResolver,
        System.Web.Mvc.IDependencyResolver
    {
        public NinjectResolver()
            : this(new StandardKernel())
        {
        }

        private readonly IKernel m_kernel;

        public NinjectResolver(IKernel ninjectKernel)
        {
            m_kernel = ninjectKernel;
            AddBindings(m_kernel);
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public object GetService(Type serviceType)
        {
            return m_kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return m_kernel.GetAll(serviceType);
        }
        public void Dispose()
        {
            // do nothing
        }
        public void AddBindings(params Action<IKernel>[] bindings)
        {
            if (bindings == null)
            {
                return;
            }
            foreach (var item in bindings)
            {
                item(m_kernel);
            }
        }
        private void AddBindings(IKernel kernel)
        {
            //kernel.Bind<IRepository>().To<Repository>().InRequestScope();
        }
    }
}