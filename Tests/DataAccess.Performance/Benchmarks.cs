using System.Threading.Tasks;
using DataAccess.Connection;
using DependencyResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataAccess.Performance
{
    [TestClass]
    public class Benchmarks
    {
        IStrategyFactory _factory;
        private SessionFactory _sessionFactory;

        [TestInitialize]
        public void Setup()
        {
            _factory = new StrategyFactory();
            _sessionFactory = new SessionFactory(new MsSql2008CustomConfiguration());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sessionFactory.Dispose();
        }

        [TestMethod]
        public void execute_1000_random_crud_operations_against_database()
        {
            // missing a test case feature like nunit here
            Parallel.For(0, 1000, i => Execute(i % 3));
        }

        private void Execute(int i)
        {
            var session = _sessionFactory.CreateSession();

            switch (i)
            {
                case 0:
                    _factory.CreatePerson(session).Execute();
                    break;

                case 1:
                    _factory.UpdatePerson(session).Execute();
                    break;

                case 2:
                    _factory.DeletePerson(session).Execute();
                    break;
            }
        }
    }
}
