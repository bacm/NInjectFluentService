using Business;
using DataAccess;

namespace Absenteeismbe
{
    public interface IAbsenceUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }
    }
}
