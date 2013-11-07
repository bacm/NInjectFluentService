using System;
using System.ServiceModel;
using System.Threading;
using Absenteeismbe;
using Absenteeismbe.Model;
using Business;

namespace WcfService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class AbsenteeismbeService : IAbsenteeismbeService
    {
        private readonly IAbsenceAdderLogic _absenceAdderLogic;

        public AbsenteeismbeService(IAbsenceAdderLogic absenceAdderLogic)
        {
            _absenceAdderLogic = absenceAdderLogic;
        }

        public string AddAbsence(AddFoldRequest request)
        {
            var fold = AutoMapper.Mapper.Map<AddFoldRequest, Absence>(request);

            var seed = new Random().Next(1000);
            var sleep = new Random(seed).Next(500, 3000);

            var channel = OperationContext.Current
                .GetCallbackChannel<IAbsenteeismbeServiceCallback>();

            channel.OnCallback(string.Format("client {0} sleeping {1} ms", request.Description, sleep));

            Thread.Sleep(sleep);

            channel.OnCallback(string.Format("client {0} adding {1} successfull and sleeping back for {2}", 
                request.Description, request.PersonId, sleep));

            Thread.Sleep(sleep);

            return _absenceAdderLogic.AddAbsence(fold);
        }
    }
}
