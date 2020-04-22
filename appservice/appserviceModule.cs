using contract;
using System;
using Volo.Abp.Modularity;

namespace appservice
{
    [DependsOn(typeof(contractModule))]
    public class appserviceModule : AbpModule
    {
    }
}
