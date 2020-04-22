using contract;
using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace webapi
{
    [RemoteService]
    // [Area("productManagement")]
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

        public UserDTO GetUser()
        {
            var obj = _user.GetUser();
            return obj;
        }
    }
}
