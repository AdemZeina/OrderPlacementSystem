using System;
using System.Collections.Generic;
using System.Text;
using Order.Domain.Entities;

namespace Order.Business
{
    public interface IOrderBusiness
    {
        Guid SaveOrderAsDraft(Users order);
    }
}
