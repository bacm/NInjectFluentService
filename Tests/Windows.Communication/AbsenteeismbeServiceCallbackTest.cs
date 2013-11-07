using System;
using Tests.ServiceReference1;

namespace Tests.Windows.Communication
{
    public class AbsenteeismbeServiceCallbackTest : IAbsenteeismbeServiceCallback
    {
        public OnCallbackResponse OnCallback(OnCallbackSolicit request)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOnCallback(OnCallbackSolicit request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public OnCallbackResponse EndOnCallback(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}