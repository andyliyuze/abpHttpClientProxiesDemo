using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abpDemo
{
    public class MyaspectAttribute : AbstractInterceptorAttribute
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                //方法调用之前
                Console.WriteLine("Before");
                return context.Invoke(next);
            }
            catch (Exception)
            {
                //方法抛异常调用
                Console.WriteLine("exception!");
                throw;
            }
            finally
            {
                //方法完成之后调用
                Console.WriteLine("After");
            }
        }
    }
}
