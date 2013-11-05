using System.ServiceModel;
using Absenteeismbe.Model;

namespace WcfService
{
    [ServiceContract]
    public interface IAbsenteeismbeService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string AddAbsence(AddFoldRequest request);
    }
}
