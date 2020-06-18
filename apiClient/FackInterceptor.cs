using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DynamicProxy;

namespace apiClient
{
    public class FackInterceptor : AbpInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("记录日志" + invocation.Proxy);
            invocation.ReturnValue = InterceptAsync(invocation);


        }

        public override async Task InterceptAsync(IAbpMethodInvocation invocation)
        {
            await invocation.ProceedAsync();
        }

        private async Task InterceptAsync(IInvocation invocation)
        {
            var proceed = invocation.CaptureProceedInfo();
            await Task.CompletedTask;
            proceed.Invoke();// will not proceed, but reenter this interceptor
                             // or--if this isn't the first--an earlier one!
        }
    }
}
