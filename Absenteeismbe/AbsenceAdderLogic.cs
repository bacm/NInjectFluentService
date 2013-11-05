using Business;
using DataAccess;

namespace Absenteeismbe
{
    /// <summary>
    /// the term logic is too broad, we should not be using that
    /// </summary>
    public class AbsenceAdderLogic : IAbsenceAdderLogic
    {
        private readonly IRepository<Person> _repository;

        public AbsenceAdderLogic(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public string AddAbsence(Absence absence)
        {
            return absence.Start.ToShortDateString();
        }
    }
}