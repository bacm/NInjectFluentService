using NHibernate;

namespace Tests.DataAccess.Performance
{
    internal interface IStrategyFactory
    {
        IStrategy CreatePerson(ISession session);
        IStrategy UpdatePerson(ISession session);
        IStrategy DeletePerson(ISession session);
    }
}