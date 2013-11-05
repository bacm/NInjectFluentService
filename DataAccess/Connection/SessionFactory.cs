using System;
using NHibernate;

namespace DataAccess.Connection
{
    public class SessionFactory : IDisposable
    {
        private readonly ISessionFactory _factory;

        public ISession CreateSession()
        {
            return _factory.OpenSession();
        }

        public SessionFactory(ICustomConfiguration configuration)
        {
            _factory = configuration.Configuration.BuildSessionFactory();
        }

        public void Dispose()
        {
            _factory.Close();
            _factory.Dispose();
        }
    }
}
