using apiClient;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace ConsoleApp1
{
    [DependsOn(
        typeof(apiClientModule)
        )]
    public class ConsoleClientDemoModule : AbpModule
    {

    }
}
