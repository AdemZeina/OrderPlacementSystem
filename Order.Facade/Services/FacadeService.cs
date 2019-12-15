using System;
using System.Collections.Generic;
using System.Text;
using Order.Business;
using Order.Domain.Entities;
using Order.Facade.Dto;

namespace Order.Facade.Services
{
    public class FacadeService: IFacadeService
    {
        private readonly IOrderBusiness _orderBusiness;

        public FacadeService(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
        public Guid SaveOrderAsDraft()
        {
            var user = new Users();
            user.FirsName = "adem";
            user.LastName = "gggg";
            user.Email = "msz.wu@hotmail.com";
            user.Password = "1234";
            user.UserName = "mszwu";
           return _orderBusiness.SaveOrderAsDraft(user);
        }

        public void Cancel()
        {

        }

        public void Submit()
        {

        }

        public OrderItem SaveOrderItem(SaveOrderItemModelDto orderItem)
        {
            return new OrderItem();
        }

        public bool DeleteItem(Guid itemId)
        {
            return true;
        }

        public FilterOrdersDto FilterOrders(OrderFilterArgs args)
        {
            throw new NotImplementedException();
        }

    }
}
