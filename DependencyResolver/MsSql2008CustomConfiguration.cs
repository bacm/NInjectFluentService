using DataAccess.Connection;
using FluentNHibernate.Cfg.Db;

namespace DependencyResolver
{
    public class MsSql2008CustomConfiguration : CustomConfiguration
    {
        protected override IPersistenceConfigurer CreatePersistenceConfigurer()
        {
            var connString = 
                System.Configuration.ConfigurationManager
                    .ConnectionStrings["Connection"];

            return MsSqlConfiguration
                .MsSql2008
                .ConnectionString(connString.ConnectionString)
                .ShowSql();
        }
    }
}