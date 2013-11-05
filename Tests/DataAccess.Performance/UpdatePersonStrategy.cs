using Extensions;
using NHibernate;

namespace Tests.DataAccess.Performance
{
    internal class UpdatePersonStrategy : IStrategy
    {
        private readonly ISession _session;

        public UpdatePersonStrategy(ISession session)
        {
            _session = session;
        }

        public void Execute()
        {
            var person = _session.GetRandom();

            if (person == null) return;

            person.FirstName = StringGenerator.RandomString(15);
            person.LastName = StringGenerator.RandomString(15);

            _session.Update(person);
        }
    }
}