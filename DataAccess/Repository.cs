using System.Collections.Generic;
using System.Linq;
using DataAccess.Specifications;
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

        public T Single(ISpecification specification)
        {
            return _session.Query<T>().Single(specification.IsSatisfiedBy);
        }

        public IEnumerable<T> Future(ISpecification specification)
        {
            return _session.Query<T>().Where(specification.IsSatisfiedBy);
        }
    }
}