using Business;
using DataAccess;

namespace Absenteeismbe
{
    public class AbsenceUnitOfWork : IAbsenceUnitOfWork
    {
        private readonly IRepository<Person> _personRepository;

        public AbsenceUnitOfWork(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IRepository<Person> PersonRepository { get { return _personRepository; } }
    }
}