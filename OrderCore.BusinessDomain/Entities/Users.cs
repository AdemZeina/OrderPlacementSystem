using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Entities
{
    public class Users : Entity
    {
        [Required]
        [MinLength(3)]
        public string FirsName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
