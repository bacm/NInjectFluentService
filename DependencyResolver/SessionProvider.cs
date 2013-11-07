using System;
using DataAccess.Connection;
using Ninject.Activation;

namespace DependencyResolver
{
    public class SessionProvider : IProvider
    {
        private static readonly SessionFactory SessionFactory =
            new SessionFactory(new MsSql2008CustomConfiguration());

        public SessionProvider()
        {
            Type = typeof (NHibernate.ISession);
        }

        public object Create(IContext context)
        {
            return SessionFactory.CreateSession();
        }

        public Type Type { get; private set; }
    }
}