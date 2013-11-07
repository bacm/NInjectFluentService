using System.Collections.Generic;
using DataAccess.Specifications;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        T Single(ISpecification specification);
        IEnumerable<T> Future(ISpecification specification);
    }
}