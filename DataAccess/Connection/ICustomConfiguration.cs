using NHibernate.Cfg;

namespace DataAccess.Connection
{
    public interface ICustomConfiguration
    {
        Configuration Configuration { get; }
    }
}