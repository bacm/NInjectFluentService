using Absenteeismbe;
using Absenteeismbe.Model;
using Business;

namespace WcfService
{
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
            return _absenceAdderLogic.AddAbsence(fold);
        }
    }
}
