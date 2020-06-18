using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace contract
{
    public interface IFackService : IApplicationService
    {
        void SayHello();
    }
}
