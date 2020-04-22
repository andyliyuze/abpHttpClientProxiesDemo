using contract;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Http.Client;

namespace appservice2
{
    public class orderService : ApplicationService, IOrderService
    {

        private readonly IUser _user;

        private readonly AbpRemoteServiceOptions _remoteServiceOptions;

        public orderService(IUser productAppService, IOptions<AbpRemoteServiceOptions> remoteServiceOptions)
        {

            _remoteServiceOptions = remoteServiceOptions.Value;
            _user = productAppService;
        }

        public OrderDTO GetOrder()
        {
            var user =_user.GetUser();

            var order = new OrderDTO() { BuyerName = user.Name, OrderNo = "123" };

            return order;
        }
    }
}
