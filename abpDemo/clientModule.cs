using apiClient;
using Volo.Abp;
using Volo.Abp.Modularity;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.Mvc;

namespace abpDemo
{
    [DependsOn(
    typeof(apiClientModule), typeof(AbpAspNetCoreMvcModule)
    )]
    public class clientModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseRouting();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }
}
