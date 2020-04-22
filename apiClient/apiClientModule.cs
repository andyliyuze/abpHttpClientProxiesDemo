using contract;
using Microsoft.Extensions.DependencyInjection;
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

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(contractModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
