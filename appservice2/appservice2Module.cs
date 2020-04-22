
using apiClient;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace appservice
{
    [DependsOn(typeof(apiClientModule))]
    [DependsOn(
      typeof(AbpDddApplicationModule)
      )]
    public class appservice2Module : AbpModule
    {
    }
}
