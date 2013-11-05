using Business;
using DataAccess;
using DataAccess.Connection;
using Extensions;
using NHibernate;

namespace Tests.DataAccess.Performance
{
    internal class CreatePersonStrategy : IStrategy
    {
        private readonly ISession _session;

        public CreatePersonStrategy(ISession session)
        {
            _session = session;
        }

        public void Execute()
        {
            var person = new Person
            {
                FirstName = StringGenerator.RandomString(15),
                LastName = StringGenerator.RandomString(15)
            };

            _session.Save(person);
        }
    }
}