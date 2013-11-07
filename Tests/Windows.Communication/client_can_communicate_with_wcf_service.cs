using System.ServiceModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.ServiceReference1;

namespace Tests.Windows.Communication
{
    [TestClass]
    public class client_can_communicate_with_wcf_service
    {
        [TestMethod]
        public void it_should_be_able_to_create_a_client_proxy()
        {
            using (var client = new AbsenteeismbeServiceClient(
                new InstanceContext(new AbsenteeismbeServiceCallbackTest())))
            {
                Assert.IsTrue(client.State == CommunicationState.Created);
            }
        }

        [TestMethod]
        public void it_should_be_able_to_call_some_method_using_async()
        {
            using (var client = new AbsenteeismbeServiceClient(
                new InstanceContext(new AbsenteeismbeServiceCallbackTest())))
            {
                string someValue = null;

                var result = client.BeginAddAbsence(new AddAbsenceRequest(new AddFoldRequest()), 
                    ar => someValue = string.Empty, null);

                while (!result.IsCompleted)
                {
                    Thread.Sleep(10);
                }

                Assert.AreEqual(string.Empty, someValue);
            }
        }
    }
}
