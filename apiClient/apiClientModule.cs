using appservice;
using Castle.DynamicProxy;
using contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace apiClient
{
    [DependsOn(
      typeof(contractModule),
      typeof(AbpHttpClientModule))]
    public class apiClientModule : AbpModule
    {
        public const string RemoteServiceName = "UserManagement";
        private static readonly ProxyGenerator ProxyGeneratorInstance = new ProxyGenerator();
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddHttpClientProxies(
            //    typeof(contractModule).Assembly,
            //    RemoteServiceName
            //);

            context.Services.AddHttpClientProxy<IUser>(
                 RemoteServiceName + "User"
            );
            //var type = typeof(FackInterceptor);

            //context.Services.OnRegistred(a =>
            //{

            //    a.Interceptors.TryAdd<FackInterceptor>();
            //});

            //// var tar = context.Services.GetServiceLazy<IFackService>().Value;
            //context.Services.AddTransient(typeof(IFackService), a =>
            //{
            //    //var tar = a.GetRequiredService<IFackService>();
            //    return ProxyGeneratorInstance.CreateInterfaceProxyWithTarget<IFackService>(a.GetRequiredService<IFackService>(), (IInterceptor)a.GetRequiredService(type));
            //}
            // );

        }


       

    }
}
