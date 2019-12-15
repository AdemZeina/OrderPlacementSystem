using System;
using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Entities
{
    public class Entity: IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid CreatedUser { get; set; }

        public Guid? UpdatedUser { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
