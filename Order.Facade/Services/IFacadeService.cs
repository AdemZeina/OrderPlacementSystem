using System;
using System.Collections.Generic;
using System.Text;
using Order.Domain.Entities;
using Order.Facade.Dto;

namespace Order.Facade.Services
{
    public interface IFacadeService
    {
        Guid SaveOrderAsDraft();

        OrderItem SaveOrderItem(SaveOrderItemModelDto orderItem);

        bool DeleteItem(Guid itemId);

        void Cancel();

        void Submit();

        FilterOrdersDto FilterOrders(OrderFilterArgs args);
    }
}
