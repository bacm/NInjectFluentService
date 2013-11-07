using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading;
using Absenteeismbe;
using Absenteeismbe.Model;
using Business;
using DataAccess.Specifications;

namespace WcfService
{
    [ServiceKnownType("SearchSpecificationsTypes")]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class AbsenteeismbeService : IAbsenteeismbeService
    {
        private readonly IAbsenceUnitOfWork _unitOfWork;
        private readonly IAbsenceModelFactory _absenceModelFactory;

        private static Type[] SearchSpecificationsTypes()
        {
            return new[]
                {
                    typeof(PersonNameSpecification)
                };
        }

        public AbsenteeismbeService(
            IAbsenceUnitOfWork unitOfWork,
            IAbsenceModelFactory absenceModelFactory)
        {
            _unitOfWork = unitOfWork;
            _absenceModelFactory = absenceModelFactory;
        }

        public string AddAbsence(AddFoldRequest request)
        {
            var fold = AutoMapper.Mapper.Map<AddFoldRequest, Absence>(request);

            DoSomeCallbacks(request);
            DoSomeDataAccess(request);

            return DateTime.Now.ToLongTimeString();
        }

        public ICollection<object> Search(ICollection<ISpecification> specifications)
        {
            return new Collection<object>();
        }

        private void DoSomeDataAccess(AddFoldRequest request)
        {
            var testers = _unitOfWork.PersonRepository.Future(
                new PersonNameSpecification("test1")
                    .Or(new PersonNameSpecification("test2"))
                    .Or(new PersonNameSpecification("test3")));
        }

        private void DoSomeCallbacks(AddFoldRequest request)
        {
            var seed = new Random().Next(1000);
            var sleep = new Random(seed).Next(500, 3000);

            var channel = OperationContext.Current
                .GetCallbackChannel<IAbsenteeismbeServiceCallback>();

            channel.OnCallback(string.Format("client {0} sleeping {1} ms", request.Description, sleep));

            Thread.Sleep(sleep);

            channel.OnCallback(string.Format("client {0} adding {1} successfull and sleeping back for {2}",
                request.Description, request.PersonId, sleep));

            Thread.Sleep(sleep);
        }
    }
}
