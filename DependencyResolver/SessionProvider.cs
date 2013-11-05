using System;
using DataAccess.Connection;
using Ninject.Activation;

namespace DependencyResolver
{
    public class SessionProvider : IProvider
    {
        private static readonly CustomConfiguration Configuration =
            new InMemoryCustomConfiguration();

        public SessionProvider()
        {
            Type = typeof (NHibernate.ISession);
        }

        public object Create(IContext context)
        {
            return new SessionFactory(Configuration).CreateSession();
        }

        public Type Type { get; private set; }
    }
}