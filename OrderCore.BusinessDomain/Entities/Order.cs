using System;
using System.Collections.Generic;
using Order.Domain.enums;

namespace Order.Domain.Entities
{

    public class Order : Entity
    {
        public virtual string Code { get; set; }

        public virtual DateTime ServiceScheduleDate { get; set; }

        public virtual OrderStatus Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Users User { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem : Entity
    {
        public virtual Order Order { get; set; }
        public virtual ServicePricing ServicePricing { get; set; }
        public virtual decimal Price { get; set; }

        public virtual string FromAddress { get; set; }

        public virtual string ToAddress { get; set; }

        public virtual string Note { get; set; }
    }
}
