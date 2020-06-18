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
            //�ӿڳ���
            string assemblyInterName = "contract";
            //ʵ�������
            string assemblyObjName = "appservice";
            var interTypes = Assembly.Load(assemblyInterName).GetTypes().Where(t => t.IsInterface && iNeedInject.IsAssignableFrom(t)).ToArray();
            foreach (var interType in interTypes)
            {
                var objType = Assembly.Load(assemblyObjName).GetTypes().Where(t => t.IsClass && interType.IsAssignableFrom(t)).SingleOrDefault();
                if (objType == null)
                {
                    continue;
                }
                //ע��ʵ����
                services.AddScoped(objType);
                //ע��ӿ�
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
            //    //ʹ��ͨ������ض�ȫ��������
            //    config.Interceptors.AddTyped<MyaspectAttribute>(Predicates.ForService("*FackService"));
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
