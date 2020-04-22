using contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace webapi
{
    [DependsOn(
       typeof(contractModule),
       typeof(AbpAspNetCoreMvcModule))]
    public class webApiMoudule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(contractModule).Assembly);
            });
        }
    }
}
