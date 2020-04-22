using appservice;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;
using webapi;

namespace host
{
    [DependsOn(
       //Product
       typeof(appserviceModule),
       typeof(webApiMoudule)
       )]
    public class HostModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();

        }
    }
}
