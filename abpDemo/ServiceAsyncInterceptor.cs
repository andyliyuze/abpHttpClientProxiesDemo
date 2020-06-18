using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;

namespace abpDemo
{
    public class ServiceAsyncInterceptor : IAsyncInterceptor
    {
        public void InterceptAsynchronous(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsynchronous(invocation);
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {

            invocation.ReturnValue = InternalInterceptAsynchronous(invocation);

        }

        private async Task InternalInterceptAsynchronous(IInvocation invocation)
        {
            // Step 1. Do something prior to invocation.
            Console.WriteLine("1111");
            invocation.Proceed();
            var task = (Task)invocation.ReturnValue;
            await task;

            // Step 2. Do something after invocation.
            Console.WriteLine("2222");
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            // Step 1. Do something prior to invocation.
            Console.WriteLine("1111");
            invocation.Proceed();
            Console.WriteLine("2222");
            // Step 2. Do something after invocation.
        }

        private async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            // Step 1. Do something prior to invocation.
            Console.WriteLine("3333");
            invocation.Proceed();
            var task = (Task<TResult>)invocation.ReturnValue;
            TResult result = await task;

            // Step 2. Do something after invocation.
            Console.WriteLine("4444");
            return result;
        }
    }
}
