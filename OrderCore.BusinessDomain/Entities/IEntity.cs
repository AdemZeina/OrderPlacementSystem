using System;

namespace Order.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        Guid CreatedUser { get; set; }

        Guid? UpdatedUser { get; set; }

        DateTime? DeletedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}
