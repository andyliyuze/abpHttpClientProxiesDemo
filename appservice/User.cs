using contract;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace appservice
{
    public class User : ApplicationService, IUser
    {
        public async Task<UserDTO> GetUser()
        {
            return await Task.FromResult(new UserDTO() { Email = "737305576@qq.com", Id = Guid.NewGuid().ToString(), Name = "Liyuze" });
        }
    }
}
