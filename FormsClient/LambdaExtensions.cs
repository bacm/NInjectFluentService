using System;
using System.Windows.Forms;

namespace FormsClient
{
    public static class LambdaExtensions
    {
        public static void InvokeAction(this Control control, Action action)
        {
            control.Invoke((Delegate)action);
        }
    }
}