using DataAccess.Connection;
using FluentNHibernate.Cfg.Db;

namespace DependencyResolver
{
    public class InMemoryCustomConfiguration : CustomConfiguration
    {
        protected override IPersistenceConfigurer CreatePersistenceConfigurer()
        {
            return SQLiteConfiguration.Standard.InMemory().ShowSql();
        }
    }
}