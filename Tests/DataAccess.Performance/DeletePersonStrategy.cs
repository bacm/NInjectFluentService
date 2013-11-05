using NHibernate;

namespace Tests.DataAccess.Performance
{
    internal class DeletePersonStrategy : IStrategy
    {
        private readonly ISession _session;

        public DeletePersonStrategy(ISession session)
        {
            _session = session;
        }

        public void Execute()
        {
            var person = _session.GetRandom();

            if (person == null) return;

            _session.Delete(person);
        }
    }
}