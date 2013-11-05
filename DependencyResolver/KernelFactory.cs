using Absenteeismbe;
using DataAccess;
using NHibernate;
using Ninject;

namespace DependencyResolver
{
    public class KernelFactory
    {
        public IKernel Create()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IAbsenceAdderLogic>().To<AbsenceAdderLogic>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<ISession>().ToProvider<SessionProvider>().InTransientScope();

            return kernel;
        }
    }
}