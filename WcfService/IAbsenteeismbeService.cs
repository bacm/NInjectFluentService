using System.Collections.Generic;
using System.ServiceModel;
using Absenteeismbe.Model;
using Business;
using DataAccess.Specifications;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IAbsenteeismbeServiceCallback))]
    public interface IAbsenteeismbeService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string AddAbsence(AddFoldRequest request);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ICollection<object> Search(ICollection<ISpecification> specifications);
    }
}
