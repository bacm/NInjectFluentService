using System;
using DataAccess;
using DataAccess.Connection;
using DependencyResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Rhino.Mocks;

namespace Tests.DataAccess.UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        private ISession _session;
        private ISpecification<object> _specification;

        private Repository<object> _repository;
        private readonly SessionFactory _factory;

        public RepositoryTests()
        {
            _factory = new SessionFactory(new MsSql2008CustomConfiguration());
        }

        [TestInitialize]
        public void Setup()
        {
            _session = _factory.CreateSession();
            _specification = MockRepository.GenerateMock<ISpecification<object>>();
            _repository = new Repository<object>(_session);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _session.Close();
            _factory.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void calling_single_with_unmatched_spefication_should_throw()
        {
            _specification.Expect(x => x.IsSatisfiedBy(null)).Return(false);
            _repository.Single(_specification);
        }
    }
}
