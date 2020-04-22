using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace contract
{
    [DependsOn(      
      typeof(AbpDddApplicationModule)
      )]
    public class contractModule :  AbpModule
    {
    }
}
