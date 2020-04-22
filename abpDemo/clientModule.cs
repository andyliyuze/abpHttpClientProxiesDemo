using apiClient;
using Volo.Abp;
using Volo.Abp.Modularity;
using Microsoft.AspNetCore.Builder;
namespace abpDemo
{
    [DependsOn(
    typeof(apiClientModule)     
    )]
    public class clientModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //var app = context.GetApplicationBuilder();

            //app.UseRouting();
            //app.UseMvcWithDefaultRouteAndArea();

        }
    }
}
