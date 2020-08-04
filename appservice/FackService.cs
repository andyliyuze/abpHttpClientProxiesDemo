using abpDemo;
using contract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace appservice
{
    [Myaspect]
    public class FackService : ApplicationService, IFackService
    {
        //Volo.Abp.EventBus.IEventBus
        public void SayHello()
        {
            new HttpClient().GetAsync("http://www.baidu.com").Wait();
            Console.WriteLine("你好");
        }
    }
}
