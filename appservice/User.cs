using contract;
using System;
using Volo.Abp.Application.Services;

namespace appservice
{
    public class User : ApplicationService, IUser
    {
        public UserDTO GetUser()
        {
            return new UserDTO() { Email = "737305576@qq.com", Id = Guid.NewGuid().ToString(), Name = "Liyuze" };
        }
    }
}
