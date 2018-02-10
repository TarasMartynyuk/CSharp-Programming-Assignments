using System;
using System.Threading.Tasks;

namespace Lab1
{
    public class DateSubmitCommandAsync : AsyncCommandBase
    {
        protected override Task ExecuteImplAsync(object o)
        {
            throw new NotImplementedException();
        }

        protected override bool CanExecuteImpl(object o) => true;
    }
}