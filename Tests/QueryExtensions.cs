using System;
using System.Linq;
using Business;
using NHibernate;
using NHibernate.Linq;

namespace Tests
{
    public static class QueryExtensions
    {
        public static Person GetRandom(this ISession session)
        {
            var cnt = session.Query<Person>().Count();
            var position = new Random().Next(cnt - 1);

            return session.Query<Person>().Skip(position).Take(1).Single();
        }
    }
}