using System;
using System.Linq;
using System.Reflection;
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace abpDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterAppService(services);
            services.AddApplication<clientModule>();
        }

        public void RegisterAppService(IServiceCollection services)
        {
            Type iNeedInject = typeof(IFackService);
            //接口程序集
            string assemblyInterName = "contract";
            //实现类程序集
            string assemblyObjName = "appservice";
            var interTypes = Assembly.Load(assemblyInterName).GetTypes().Where(t => t.IsInterface && iNeedInject.IsAssignableFrom(t)).ToArray();
            foreach (var interType in interTypes)
            {
                var objType = Assembly.Load(assemblyObjName).GetTypes().Where(t => t.IsClass && interType.IsAssignableFrom(t)).SingleOrDefault();
                if (objType == null)
                {
                    continue;
                }
                //注册实现类
                services.AddScoped(objType);
                //注册接口
                services.AddScoped(interType, a =>
                 {
                     var impl = a.GetService(objType);
                     var generator = new ProxyGenerator();
                     var interceptor = new ServiceAsyncInterceptor();
                     var proxy = generator.CreateInterfaceProxyWithTargetInterface(interType, impl, interceptor);
                     return proxy;
                 });
            }

            //services.ConfigureDynamicProxy(config =>
            //{
            //    //使用通配符的特定全局拦截器
            //    config.Interceptors.AddTyped<MyaspectAttribute>(Predicates.ForService("*FackService"));
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
