using System;
using System.Collections.Generic;
using System.Text;
using Order.Domain.Entities;
using Order.Domain.enums;

namespace Order.Facade.Dto
{
    public class OrderModelDto
    {
        public virtual string Code { get; set; }

        public virtual DateTime ServiceScheduleDate { get; set; }

        public virtual OrderStatus Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Users User { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
