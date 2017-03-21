using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Dominio.Abstracto;
using Dominio.Concreto;

namespace WebUI.Infraestructura1
{
    public class NinjectDependenciaResuelta:IDependencyResolver
    {
            private IKernel kernel;

            public NinjectDependenciaResuelta(IKernel kern)
            {
                kernel = kern;
                AddBindigs();
            }

            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }

            private void AddBindigs()
            {
                 kernel.Bind<IWebAdminUsers>().To<WebAdminUsers>();
                 kernel.Bind<ISuministroRespositorio>().To<SuministroRepositorio>();
                 kernel.Bind<IComputadorasRepositorio>().To<ComputadoraRepositorio>();
            }
        }
    
}