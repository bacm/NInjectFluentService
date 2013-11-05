using Business;
using FluentNHibernate.Mapping;

namespace Mapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("People");

            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
