using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Entities
{
    public class Service : Entity
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        public int SortingNumber { get; set; } = 0;

        public List<ServicePricing> ServicePricing { get; set; }
    }

    public class ServicePricing: Entity
    {
        public Service Service { get; set; }

        public string Attribute { get; set; }
        public string Price { get; set; }
    }
}
