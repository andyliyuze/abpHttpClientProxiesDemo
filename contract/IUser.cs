using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace contract
{
    public interface IUser : IApplicationService
    {
      Task<UserDTO> GetUser();
    }
}
