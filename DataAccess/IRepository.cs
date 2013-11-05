using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        T Single(ISpecification<T> specification);
        IEnumerable<T> Future(ISpecification<T> specification);
    }
}