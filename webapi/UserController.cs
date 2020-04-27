using contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace webapi
{
    [RemoteService]
    [Route("api/user")]
    public class UserController : AbpController, IUser
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("getUser")]

        public async Task<UserDTO> GetUser()
        {
            var obj = await _user.GetUser();
            return obj;
        }
    }
}
