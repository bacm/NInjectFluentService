using System;
using System.Collections.Generic;
using NHibernate;

namespace DataAccess.Connection
{
    public class SessionFactory : IDisposable
    {
        private readonly ISessionFactory _factory;

        private static readonly IDictionary<int,ISession> _container = 
            new Dictionary<int, ISession>();

        public ISession CreateSession()
        {
            var tid = System.Threading.Thread.CurrentThread.ManagedThreadId;

            if (_container.ContainsKey(tid))
                return _container[tid];

            var session = _factory.OpenSession();
            _container.Add(tid, session);

            return session;
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
