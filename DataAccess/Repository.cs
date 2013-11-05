using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T Single(ISpecification<T> specification)
        {
            return _session.Query<T>().Single(specification.IsSatisfiedBy);
        }

        public IEnumerable<T> Future(ISpecification<T> specification)
        {
            return _session.Query<T>().Where(specification.IsSatisfiedBy);
        }
    }
}