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

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IAbsenceUnitOfWork>().To<AbsenceUnitOfWork>().InTransientScope();
            kernel.Bind<IAbsenceModelFactory>().To<AbsenceModelFactory>().InSingletonScope();
            kernel.Bind<ISession>().ToProvider<SessionProvider>().InThreadScope();

            return kernel;
        }
    }
}