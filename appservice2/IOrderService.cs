using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace appservice2
{
    public interface IOrderService : IApplicationService
    {
        OrderDTO GetOrder();
    }

    public class OrderDTO
    {
        public string OrderNo { get; set; }

        public string BuyerName { get; set; }

    }
}
