using System.ServiceModel;

namespace WcfService
{
    public interface IAbsenteeismbeServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback(string status);
    }
}