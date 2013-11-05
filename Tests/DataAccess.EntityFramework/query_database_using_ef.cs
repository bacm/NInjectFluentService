using System;
using System.Linq;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataAccess.EntityFramework
{
    [TestClass]
    public class query_database_using_ef
    {
        [TestMethod]
        public void can_create_context()
        {
            var ctx = new DocumentStoreTestEntities();
            Assert.IsNotNull(ctx.Database.Connection.Database); 
        }

        [TestMethod]
        public void can_get_a_list_of_something()
        {
            var ctx = new DocumentStoreTestEntities();
            Assert.IsNotNull(ctx.People.ToList());
        }
    }
}
