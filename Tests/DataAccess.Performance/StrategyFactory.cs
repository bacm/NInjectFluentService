using NHibernate;

namespace Tests.DataAccess.Performance
{
    class StrategyFactory : IStrategyFactory
    {
        public IStrategy CreatePerson(ISession session)
        {
            return new CreatePersonStrategy(session);
        }

        public IStrategy UpdatePerson(ISession session)
        {
            return new UpdatePersonStrategy(session);
        }

        public IStrategy DeletePerson(ISession session)
        {
            return new DeletePersonStrategy(session);
        }
    }
}