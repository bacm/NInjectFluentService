using Absenteeismbe.Model;
using Business;
using DependencyResolver;
using Ninject;

namespace WcfService
{
    public class Global : Ninject.Web.Common.NinjectHttpApplication
    {
        public override void Init()
        {
            AutoMapper.Mapper.CreateMap<AddFoldRequest, Absence>();

            base.Init();
        }

        protected override IKernel CreateKernel()
        {
            return new KernelFactory().Create();
        }
    }
}